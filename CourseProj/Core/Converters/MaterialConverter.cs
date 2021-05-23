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
    class MaterialConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is JewelryItemMaterial material)
            {
                switch (material)
                {
                    case JewelryItemMaterial.Gold:
                        return "Золото";
                    case JewelryItemMaterial.Silver:
                        return "Серебро";
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
