using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.MVVM.Model
{
    public class Profile
    {
        public Profile(string userName, UserType userType)
        {
            UserName = userName;
            UserType = userType;
        }
        public UserType UserType { get; }
        public string UserName { get; }
    }
}
