using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Mo.TeamCityScreensaver.classes
{
    public class Project : INotifyPropertyChanged
    {
        private readonly ObservableCollection<BuildConfiguration> mConfigs =
            new ObservableCollection<BuildConfiguration>();


        private Projects mAllProjects;

        public Project(Projects projects)
        {
            AllProjects = projects;
        }

        public ObservableCollection<BuildConfiguration> Configs
        {
            get { return mConfigs; }
        }

        public Projects AllProjects
        {
            get { return mAllProjects; }
            set
            {
                mAllProjects = value;
                OnPropertyChanged("AllProjects");
            }
        }


        public bool Archived { get; set; }
        public bool Error { get; set; }
        public string Href { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void AddBuild(BuildConfiguration bc)
        {
            mConfigs.Add(bc);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}