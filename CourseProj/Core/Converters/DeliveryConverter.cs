using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using CourseProj.MVVM.Model;

namespace CourseProj.Core.Converters
{
    class DeliveryConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DeliveryType deliveryType)
            {
                switch (deliveryType)
                {
                    case DeliveryType.Pickup:
                        return "Самовывоз";
                    case DeliveryType.Mail:
                        return "Почта";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
