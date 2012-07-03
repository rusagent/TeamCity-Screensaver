using System;
using System.Globalization;
using System.Windows.Data;

namespace Mo.TeamCityScreensaver.convert
{
    public class MessageConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Member

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string message = "";
            if (values[1] == null)
            {
                message = "No Builds for this Configuration!";
                return message;
            }

            if (values[2].ToString() == "SUCCESS")
            {
                message = values[0] + " \n\r" + "Build # " + values[1] + ", " + values[2];
            }
            else if (values[2].ToString() == "FAILURE")
            {
                message = values[0] + " \n\r" + "Build # " + values[1] + ", " + values[2];
            }
            else if (values[2].ToString() == "ERROR")
            {
                message = values[0] + " \n\r" + "Build # " + values[1] + ", " + values[2];
            }


            return message;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}