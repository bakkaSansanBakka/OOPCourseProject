using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model.Base;

namespace CourseProj.MVVM.Model
{
    public enum UserType
    {
        [Display(Name = "Администратор")]
        Admin = 1,
        [Display(Name = "Клиент")]
        Client
    }

    public class User : Item
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public IList<JewelryOrder> JewelryOrders { get; set; }

        public User() { }

        public User(int id, string userName, string password, string email, UserType userType) : base(id)
        {
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }
    }
}
