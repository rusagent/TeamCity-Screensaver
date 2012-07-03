using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Threading;
using Mo.TeamCityScreensaver.classes;

namespace Mo.TeamCityScreensaver.controls
{
    /// <summary>
    /// Interaktionslogik für ProjectsControl.xaml
    /// </summary>
    public partial class ProjectsControl
    {
        private readonly DispatcherTimer mTimer = new DispatcherTimer();
        private int mCurProject;
        private Projects mProjects;

        public ProjectsControl()
        {
            InitializeComponent();
            mTimer.Interval = new TimeSpan(0, 0, 5);
            mTimer.Tick += TimerTick;
        }

        public void InitProjectsControl(Projects projects)
        {
            mProjects = projects;
            mProjects.Items.CollectionChanged += ProjectsCollectionChanged;
        }

        private void ProjectsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            FrameworkElement container;
            foreach (object item in ProjectsItemsCtrl.Items)
            {
                container = ProjectsItemsCtrl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container == null) continue;
                container.Visibility = Visibility.Collapsed;
            }

            if (ProjectsItemsCtrl.Items.Count > 0)
            {
                if (mCurProject >= ProjectsItemsCtrl.Items.Count) mCurProject = 0;
                container =
                    ProjectsItemsCtrl.ItemContainerGenerator.ContainerFromItem(ProjectsItemsCtrl.Items[mCurProject]) as
                    FrameworkElement;

                if (container != null) container.Visibility = Visibility.Visible;
            }

            if (!mTimer.IsEnabled) mTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            FrameworkElement container;
            foreach (object item in ProjectsItemsCtrl.Items)
            {
                container = ProjectsItemsCtrl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container == null) continue;
                container.Visibility = Visibility.Collapsed;
            }

            if (ProjectsItemsCtrl.Items.Count <= 0) return;
            container =
                ProjectsItemsCtrl.ItemContainerGenerator.ContainerFromItem(ProjectsItemsCtrl.Items[mCurProject]) as
                FrameworkElement;
            if (container != null) container.Visibility = Visibility.Collapsed;

            mCurProject++;
            if (mCurProject >= ProjectsItemsCtrl.Items.Count) mCurProject = 0;
            container =
                ProjectsItemsCtrl.ItemContainerGenerator.ContainerFromItem(ProjectsItemsCtrl.Items[mCurProject]) as
                FrameworkElement;
            if (container != null) container.Visibility = Visibility.Visible;
        }
    }
}