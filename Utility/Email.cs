namespace Utility
{
    using FMS_API_BAL;
    using MailKit.Net.Smtp;
    using Microsoft.AspNetCore.Hosting;
    using MimeKit;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using UtilityService;

    public class Email : IEmail
    {
        
        public async Task<string> GetEmailTemplate(string templateType, string perticipatedDate, string eventname, string assosiateName = "Assosiate")
        {
            string emailBody = string.Empty;
            if (templateType.Equals("NotPerticipated"))
            {
                emailBody = GetNotPerticipatedEmailBodyTemplate(perticipatedDate, eventname);
            }
            else if (templateType.Equals("Perticipated"))
            {
                emailBody = GetPerticipatedBodyTemplate(perticipatedDate, eventname);
            }
            else if (templateType.Equals("Unregistered"))
            {
                emailBody = GetUnRegisteredEmailBodyTemplate(perticipatedDate, eventname);
            }

            string name = "<P>Dear " + assosiateName + ",</p>";
            StringBuilder template = new StringBuilder();

            template.Append("<table><tr><td align=\"center\"></td></tr>");
            template.Append(" <td><b>" + name + "</b><p><i> " + emailBody + " </i></p></td>");
            template.Append("<tr><td align=\"center\">FEEDBACK MANAGEMENT SYSTEM</td></tr></table>");

            return template.ToString();
        }
        public async Task<bool> Send(EmailConfig emailConfig)
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
        //public async Task<string> GetTemplate(
        //    string emailBody,
        //    string assosiateName = "Assosiate"
        //    )
        //{
        //    string name = "<P>Dear " + assosiateName + ",</p>";
        //    StringBuilder template = new StringBuilder();

        //    template.Append("<!DOCTYPE html");
        //    template.Append("<html><head><title>Feedback Management System</title></head>");
        //    template.Append("<body style=\"color:red\">");
        //    template.Append("<h2>Feedback Management System</h2>");
        //    template.Append(name);
        //    template.Append(emailBody);
        //    template.Append("</body>");
        //    template.Append("</html>");

        //    return template.ToString();
        //}
        #region Private Section
        private string GetNotPerticipatedEmailBodyTemplate(string perticipatedDate, string eventname)
        {
            return string.Format("You had registered for the {0} event on {1}." +
                " We would like to know the reason for not joining the event to understand if the " +
                "team which created this event has some room for improvement in their process, so that we get 100% participation from registered attendees.",
                eventname, perticipatedDate);
        }
        private string GetUnRegisteredEmailBodyTemplate(string perticipatedDate, string eventname)
        {
            return string.Format("You had registered for the {0} event on {1}.Your feedback is quite valuable for us. " +
                "Please give us some minutes to know why did you unregistered from the event",
                eventname, perticipatedDate);
        }
        private string GetPerticipatedBodyTemplate(string perticipatedDate, string eventname)
        {
            return string.Format("Your feedback is quite valuable for us. Please give us some minutes to know your experiences from the event",
                eventname, perticipatedDate);
        }
        #endregion
    }
}
