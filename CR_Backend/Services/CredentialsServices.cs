using CR_Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace CR_Backend.Services
{
    public static class CredentialsServices
    {
        static List<LoginRequest> Login { get; }
        static CredentialsServices()
        {
            Login = new List<LoginRequest>
            {
                new LoginRequest { Username = "admin", Password = "password"}
            };
        }

        public static bool Check(LoginRequest user){
            return Login.Exists(u => u.Username == user.Username && u.Password == user.Password);
        }

        private static void AddUser(LoginRequest user)
        {
            Login.Add(user);
        }
    }
}