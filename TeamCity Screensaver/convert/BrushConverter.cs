using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Mo.TeamCityScreensaver.convert
{
    public class BrushConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Member

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
            {
                var successGradient = new SolidColorBrush(Colors.Black);
                return successGradient;
            }
            if (values[0].ToString() == "SUCCESS" || values[0].ToString() == "False")
            {
                var successGradient = new LinearGradientBrush();
                successGradient.StartPoint = new Point(0.5, 0);
                successGradient.EndPoint = new Point(0.5, 1);
                successGradient.GradientStops.Add(new GradientStop(Colors.LimeGreen, 0.0));
                successGradient.GradientStops.Add(new GradientStop(Colors.Green, 1.0));

                return successGradient;
            }
            else if (values[0].ToString() == "ERROR" || values[0].ToString() == "True")
            {
                var errorGradient = new LinearGradientBrush();
                errorGradient.StartPoint = new Point(0.5, 0);
                errorGradient.EndPoint = new Point(0.5, 1);
                errorGradient.GradientStops.Add(new GradientStop(Colors.Tomato, 0.0));
                errorGradient.GradientStops.Add(new GradientStop(Colors.DarkRed, 1.0));
                return errorGradient;
            }
            else if (values[0].ToString() == "FAILURE")
            {
                var failureGradient = new LinearGradientBrush();
                failureGradient.StartPoint = new Point(0.5, 0);
                failureGradient.EndPoint = new Point(0.5, 1);
                failureGradient.GradientStops.Add(new GradientStop(Colors.DimGray, 0.0));
                failureGradient.GradientStops.Add(new GradientStop(Colors.Black, 1.0));
                return failureGradient;
            }

            return new SolidColorBrush(Colors.MediumVioletRed);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}