using Microsoft.AspNetCore.Identity;

namespace BlazorServerApp.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users = new();

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount { UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserAccount { UserName = "user", Password = "user", Role = "User" },
            };
        }

        public UserAccount? GetByUsername(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
