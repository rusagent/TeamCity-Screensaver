using System.Windows;

namespace Mo.TeamCityScreensaver
{
    public partial class App : Application
    {
        public string[] arguments;

        public void Init()
        {
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            arguments = e.Args;
        }
    }
}