using System;
using System.Windows;
using System.Windows.Data;

namespace Mo.TeamCityScreensaver.converter
{
    public class FontSizeConverter : IMultiValueConverter
    {

        

        #region IMultiValueConverter Member

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == DependencyProperty.UnsetValue)
                {
                    return 10;
                }
            }
            return (double)values[0] * (System.Windows.SystemParameters.PrimaryScreenHeight / (System.Windows.SystemParameters.PrimaryScreenHeight / (double)parameter));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
