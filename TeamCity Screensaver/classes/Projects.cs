using System.ComponentModel;

namespace Mo.TeamCityScreensaver.classes
{
    public class Projects : INotifyPropertyChanged
    {
        private readonly ExtendedObservableCollection<Project> mItems = new ExtendedObservableCollection<Project>();

        private bool mAllGreen;

        public ExtendedObservableCollection<Project> Items
        {
            get { return mItems; }
        }

        public bool AllGreen
        {
            get { return mAllGreen; }
            set
            {
                mAllGreen = value;
                OnPropertyChanged("AllGreen");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Clear()
        {
            mItems.Clear();
            AllGreen = true;
        }


        public void Add(Project project)
        {
            mItems.Add(project);
            AllGreen = AllGreen && !project.Error;
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