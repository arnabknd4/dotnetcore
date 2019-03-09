namespace Utility
{
    using FMS_API_BAL;
    using MailKit.Net.Smtp;
    using MimeKit;
    using System.Threading.Tasks;
    using UtilityService;

    public class Email : IEmail
    {
        public async Task<bool> send(EmailConfig emailConfig)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Constants.MESSAGE_FROM_EMAIL_NAME, Constants.MESSAGE_FROM_EMAILID));
                message.To.Add(new MailboxAddress(emailConfig.ToName, emailConfig.ToEmailAddress));
                message.Subject = emailConfig.Subject;
                message.Body = new TextPart(emailConfig.TextFormatter)
                {
                    Text = emailConfig.Body
                };
                using (var client = new SmtpClient())
                {
                    client.Connect(Constants.SMTP_SERVER, Constants.SMTP_PORT, Constants.USE_SSL);
                    client.Authenticate(Constants.AUTHENTICATED_EMAIL_ID, Constants.AUTHENTICATED_EMAIL_PASSWORD);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
