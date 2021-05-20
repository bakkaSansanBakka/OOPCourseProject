using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.MVVM.Model
{
    public class Profile
    {
        public Profile(UserType userType)
        {
            UserType = userType;
        }
        public UserType UserType { get; }
    }
}
