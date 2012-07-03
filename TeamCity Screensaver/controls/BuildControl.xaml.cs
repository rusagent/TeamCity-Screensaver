using System.Windows;
using Mo.TeamCityScreensaver.classes;

namespace Mo.TeamCityScreensaver.controls
{
    /// <summary>
    /// Interaktionslogik für BuildControl.xaml
    /// </summary>
    public partial class BuildControl
    {
        public static readonly DependencyProperty ProjectProperty = DependencyProperty.RegisterAttached("Project",
                                                                                                        typeof (Project),
                                                                                                        typeof (
                                                                                                            BuildControl
                                                                                                            ),
                                                                                                        new PropertyMetadata
                                                                                                            (null,
                                                                                                             OnProjectChanged));

        public BuildControl()
        {
            InitializeComponent();
        }

        public Project Project
        {
            get { return (Project) GetValue(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
        }

        private static void OnProjectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}