namespace UtilityService
{
    using FMS_API_BAL;
    using System.Threading.Tasks;
    public interface IEmail
    {
        Task<bool> send(EmailConfig emailConfig);
    }
}
