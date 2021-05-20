using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model;

namespace CourseProj.Core
{
    public class AuthenticationStore
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationStore(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Profile CurrentProfile { get; set; }

        public async Task<Profile> Login(string login, string password)
        {
            return await _authenticationService.Login(login, password);
        }

        public async Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email,
            UserType userType)
        {
            return await _authenticationService.Register(userName, password, confirmPassword, email, userType);
        }

        public void Logout()
        {
            CurrentProfile = null;
        }
    }
}
