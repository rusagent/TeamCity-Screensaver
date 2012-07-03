using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Mo.TeamCityScreensaver.convert
{
    public class HeadlineConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Member

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return new SolidColorBrush(Colors.Red);

            if ((bool) values[0])
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.GhostWhite);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}