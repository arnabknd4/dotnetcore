namespace Utility
{
    using MailKit.Net.Smtp;
    using MimeKit;
    using System.Threading.Tasks;
    using UtilityService;

    public class Email : IEmail
    {
        public async Task<bool> send()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Arnab", "arnabknd4@gmail.com"));
                message.To.Add(new MailboxAddress("Arnab", "arnabknd4@gmail.com"));
                message.Subject = "Sample mail test";
                message.Body = new TextPart("plain")
                {
                    Text = "Sample body"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("arnabknd4@gmail.com", "demi lavato");
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
