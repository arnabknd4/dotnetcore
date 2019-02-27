namespace FMS_API_DAL
{
    using FMS_API_BAL;
    using System.Threading.Tasks;

    public class Login_DAL
    {
        private readonly FMSContext _context;

        public Login_DAL(FMSContext context)
        {
            this._context = context;
        }
        public async Task<User> fetchUser(User user)
        {
            return await _context.Users.FindAsync(user);
        }
    }
}
