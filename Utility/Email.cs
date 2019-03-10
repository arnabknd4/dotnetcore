namespace Utility
{
    using FMS_API_BAL;
    using MailKit.Net.Smtp;
    using MimeKit;
    using System;
    using System.IO;
    using System.Text;
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
                    byte[] data = Convert.FromBase64String(Constants.AUTHENTICATED_EMAIL_PASSWORD);
                    string decodedPassword = Encoding.UTF8.GetString(data);
                    client.Connect(Constants.SMTP_SERVER, Constants.SMTP_PORT, Constants.USE_SSL);
                    client.Authenticate(Constants.AUTHENTICATED_EMAIL_ID, decodedPassword);
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
        public async Task<string> GetTemplate(string assosiateName = "Assosiate")
        {
            string name = "<P>Dear " + assosiateName + ",</p>";
            StringBuilder template = new StringBuilder();
            template.Append("<!DOCTYPE html");
            template.Append("<html><head><title>Feedback Management System</title></head>");
            template.Append("<body style=\"color:red\">");
            template.Append("<h2>Feedback Management System</h2>");
            template.Append(name);
            template.Append("<P>We're happy you perticipated in this program. Please give sometime for your valuable feedback!</p>");
            template.Append("</body>");
            template.Append("</html>");
            template.Append(template);

            return template.ToString();
        }
    }
}
