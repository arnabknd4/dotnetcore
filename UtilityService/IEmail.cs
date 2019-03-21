namespace UtilityService
{
    using FMS_API_BAL;
    using System.Threading.Tasks;
    public interface IEmail
    {
        Task<bool> Send(EmailConfig emailConfig);
        //Task<string> GetTemplate(string emailBody, string assosiateName="Assosiate");
        Task<string> GetEmailTemplate(string templateType, string perticipatedDate, string eventname, string assosiateName = "Assosiate");
    }
}
