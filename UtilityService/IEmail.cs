namespace UtilityService
{
    using System.Threading.Tasks;
    public interface IEmail
    {
        Task<bool> send();
    }
}
