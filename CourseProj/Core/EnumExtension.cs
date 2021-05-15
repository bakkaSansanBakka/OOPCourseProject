using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.Core
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return enumVal.ToString();
        }
    }
}
