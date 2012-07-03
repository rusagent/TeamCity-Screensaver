using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Mo.TeamCityScreensaver.convert
{
    public class ProjectFailConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Member

        public object Convert(object[] values, Type targetType, object parameter,
                              CultureInfo culture)
        {
            if (values[0] == null)
                return "No Projects could be loaded!";
            if (values[1] == null)
                return "Could not find DockPanel!";
            else
            {
                var panel = values[1] as DockPanel;
                if ((bool) values[0])
                {
                    if (panel != null) panel.SetValue(DockPanel.DockProperty, Dock.Right);
                    return " errors!! ";
                }
                else
                {
                    if (panel != null) panel.SetValue(DockPanel.DockProperty, Dock.Left);
                    return " no errors!! ";
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
                                    CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}