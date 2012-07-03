using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Mo.TeamCityScreensaver.Properties;
using Mo.TeamCityScreensaver.classes;
using TeamCitySharp;
using TeamCitySharp.DomainEntities;
using Project = TeamCitySharp.DomainEntities.Project;

namespace Mo.TeamCityScreensaver
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ScreenSaver
    {
        private readonly TeamCityClient mClient;
        private readonly double mDelay = 5;
        private string mPassword = "";
        private string mPort = "";
        private string mUrlPath = "";
        private string mUserName = "";

        private readonly Projects mProjectList = new Projects();

        private readonly DispatcherTimer mProjectFailureTimer = new DispatcherTimer();
        private readonly DispatcherTimer mTimer = new DispatcherTimer();
        private DoubleAnimation mFadeIn = new DoubleAnimation();
        private DoubleAnimation mFadeOut = new DoubleAnimation();
        private bool mIsactive;
        private Point mMousePosition;
        private string mProjectFailDockProperty = "";
        private bool mProjectsLoaded;
        private double mScreenheight = SystemParameters.PrimaryScreenHeight;
        private double mScreenwidth = SystemParameters.PrimaryScreenWidth;

        public ScreenSaver()
        {
            InitializeComponent();
            mDelay = Settings.Default.Delay;
            mUrlPath = Settings.Default.ImgPath;
            mPort = Settings.Default.PortPath;
            mUserName = Settings.Default.Username;
            mPassword = Settings.Default.Password;
            mClient = new TeamCityClient(mUrlPath + ":" + mPort);
            mClient.Connect(mUserName, mPassword);
            LoadProjects();
            mProjectsLoaded = true;

            ProjectsCtrl.ProjectsItemsCtrl.DataContext = ProjectList;
            ProjectsCtrl.ProjectsItemsCtrl.ItemsSource = ProjectList.Items;
            ProjectsCtrl.InitProjectsControl(ProjectList);
        }

        public Projects ProjectList
        {
            get { return mProjectList; }
        }


        private void LoadProjects()
        {
            var tempProjectList = new Projects();

            var allprojects = new List<Project>();
            try
            {
                allprojects = mClient.AllProjects();
            }
            catch (WebException exc)
            {
                
                //maybe user is not allowed to view projects
                //todo: error handling goes here
            }
            catch (Exception exc)
            {
                //todo: unable to load projects - do some good error handling here
                throw;
            }

            foreach (var projects in allprojects)
            {
                var project = new classes.Project(ProjectList)
                                  {
                                      Name = projects.Name,
                                      Href = projects.Href,
                                      Archived = projects.Archived,
                                      Id = projects.Id,
                                      Description = projects.Description,
                                      Error = false
                                  };
                foreach (BuildConfig buildConfigs in mClient.BuildConfigsByProjectName(project.Name))
                {
                    
                    var buildConfig = new BuildConfiguration {Name = buildConfigs.Name};
                    buildConfig.Description = buildConfig.Description;
                    buildConfig.WebUrl = buildConfigs.WebUrl;
                    buildConfig.Build = mClient.LastBuildByBuildConfigId(buildConfigs.Id);
                    buildConfig.ParentProject = project;

                    if ((buildConfig.Build.Status == "ERROR") || (buildConfig.Build.Status == "FAILURE"))
                    {
                        project.Error = true;
                    }
                    project.AddBuild(buildConfig);
                }
                tempProjectList.Add(project);
            }
            Dispatcher.BeginInvoke(new Action(() => SetProjects(tempProjectList)));
        }

        private void SetProjects(Projects tempProjects)
        {
            ProjectList.Items.BeginUpdate();
            ProjectList.Clear();
            foreach (classes.Project project in tempProjects.Items)
            {
                ProjectList.Add(project);
            }
            ProjectList.Items.EndUpdate();
        }

        private void WindowMouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.MouseDevice.GetPosition(this);
            // Set IsActive and MouseLocation only the first time this event is called.
            if (!mIsactive)
            {
                mMousePosition = currentPosition;
                mIsactive = true;
            }
            else
            {
                // If the mouse has moved significantly since first call, close.
                if ((Math.Abs(mMousePosition.X - currentPosition.X) > 50) ||
                    (Math.Abs(mMousePosition.Y - currentPosition.Y) > 50))
                {
                    Close();
                }
            }
        }

        private void WindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.None;


            mTimer.Interval = new TimeSpan(0, 0, (int) mDelay);
            mTimer.Tick += TimerTick;
            mTimer.Start();

            mProjectFailureTimer.Interval = new TimeSpan(0, 0, 20);
            mProjectFailureTimer.Tick += ProjectFailureTimerTick;
            mProjectFailureTimer.Start();
        }

        private void ProjectFailureTimerTick(object sender, EventArgs e)
        {
            if (mProjectFailDockProperty == "" || mProjectFailDockProperty == "right")
            {
                ProjectsPanelCtrl.SetValue(DockPanel.DockProperty, Dock.Left);
                mProjectFailDockProperty = "left";
            }
            else if (mProjectFailDockProperty == "left")
            {
                ProjectsPanelCtrl.SetValue(DockPanel.DockProperty, Dock.Right);
                mProjectFailDockProperty = "right";
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            mTimer.Stop();
            worker.DoWork += WorkerDoWork;
            worker.RunWorkerAsync();
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            LoadProjects();
            Dispatcher.BeginInvoke(new Action(() => mTimer.Start()));
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            mTimer.Stop();
            mProjectFailureTimer.Stop();
            Application.Current.Shutdown();
        }
    }
}