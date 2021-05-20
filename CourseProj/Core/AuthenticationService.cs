using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model;
using CourseProj.Repositories;

namespace CourseProj.Core
{
    public enum RegistrationResult
    {
        [Display(Name = "Успешно")]
        Success,
        [Display(Name = "Пароли не совпадают")]
        PasswordDoNotMatch,
        [Display(Name = "Логин уже существует")]
        LoginAlreadyExists
    }

    public class AuthenticationService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AuthenticationService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Profile> Login(string login, string password)
        {
            using (UnitOfwork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                User loginUser = await unitOfWork.UserRepository.GetByUserName(login);
                if (loginUser != null)
                {
                    var passwordHashier = new SaltedHasher(password);
                    if (!SaltedHasher.Verify(loginUser.Salt, loginUser.HashedPassword, password))
                    {
                        return null;
                    }
                }
                else
                    return null;

                return new Profile(loginUser.UserType);
            }
        }

        public async Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email, UserType userType)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (string.Equals(password, confirmPassword))
            {
                using (UnitOfwork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    if (await unitOfWork.UserRepository.GetByUserName(userName) != null)
                        result = RegistrationResult.LoginAlreadyExists;

                    var passwordHashier = new SaltedHasher(password);

                    User user = new User()
                    {
                        UserName = userName,
                        HashedPassword = passwordHashier.Hash,
                        Salt = passwordHashier.Salt,
                        Email = email,
                        UserType = userType
                    };


                    if (result == RegistrationResult.Success)
                    {
                        unitOfWork.UserRepository.Create(user);
                        await unitOfWork.SaveAsync();
                    }
                }
            }
            else
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            return result;

        }
    }
}
