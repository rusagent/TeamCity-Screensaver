using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Mo.TeamCityScreensaver.Properties;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Mo.TeamCityScreensaver
{
    /// <summary>
    /// Logique d'interaction pour Configuration.xaml
    /// </summary>
    public partial class Configuration
    {
        private readonly double mDelay;
        private readonly NotifyIcon mNi = new NotifyIcon();
        private readonly DispatcherTimer mTimer = new DispatcherTimer();
        private bool mManual;

        private int mSeconds;
        private string mWaitTime;

        public Configuration()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                                                              {
                                                                  if (e.IsTerminating)
                                                                  {
                                                                      object o = e.ExceptionObject;
                                                                      MessageBox.Show(o.ToString());
                                                                  }
                                                              };
            InitializeComponent();


            mDelay = Settings.Default.Delay;
            DelaySlider.Value = mDelay;
            txtUrl.Text = Settings.Default.ImgPath != "null" ? Settings.Default.ImgPath : "";
            txtPort.Text = Settings.Default.PortPath != "null" ? Settings.Default.PortPath : "";
            txtPassword.Text = Settings.Default.Password != "null" ? Settings.Default.Password : "";
            txtUsername.Text = Settings.Default.Username != "null" ? Settings.Default.Username : "";

            //UpdateSeconds();

            var app = (App) Application.Current;
            string[] args = app.arguments;


            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.  
                // Examples: /c:1234567 or /P:1234567 
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c") // Configuration mode 
                {
                    Show();
                }
                else if (firstArgument == "/p") // Preview mode 
                {
                    Close();
                    Application.Current.Shutdown();
                    return;
                }
                else if (firstArgument == "/s") // Full-screen mode 
                {
                    StartScreenSaver();
                }
                else // Undefined argument  
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
                                    "\" is not valid.");
                }
            }
            else // No arguments - treat like /c 
            {
                Close();
                Application.Current.Shutdown();
                return;
            }

            /*   mTimer.Interval = TimeSpan.FromSeconds(1);
            mTimer.Tick += TimerTick;
            mTimer.Start();


            mNi.Icon =
                new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("Mo.TeamCityScreensaver.icon.ico"));
            mNi.Visible = true;
            mNi.DoubleClick +=
                delegate
                    {
                        Show();
                        WindowState = WindowState.Normal;
                    };

            mCtxTrayMenu = new ContextMenuStrip {ShowImageMargin = false, ShowCheckMargin = false};
            var mnuSet = new ToolStripMenuItem {Text = @"Settings"};
            mnuSet.Click += MnuSetClick;

            var mnuPrev = new ToolStripMenuItem {Text = @"Preview"};
            mnuPrev.Click += mnuPrev_Click;

            var mnuExit = new ToolStripMenuItem {Text = @"Exit"};
            mnuExit.Click += MnuExitClick;

            mCtxTrayMenu.Items.Add(mnuSet);
            mCtxTrayMenu.Items.Add(mnuPrev);
            mCtxTrayMenu.Items.Add(new ToolStripSeparator());
            mCtxTrayMenu.Items.Add(mnuExit);
            mNi.ContextMenuStrip = mCtxTrayMenu;

            */
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private void mnuPrev_Click(object sender, EventArgs e)
        {
            var ss = new ScreenSaver();
            ss.ShowDialog();
        }

        private void UpdateSeconds()
        {
            mWaitTime = Settings.Default.StartTime;
            if (mWaitTime == "null" || !IsNumeric(mWaitTime))
                mSeconds = 300;
            else
                mSeconds = Convert.ToInt32(mWaitTime)*60;
        }

        private void MnuSetClick(object sender, EventArgs e)
        {
            Show();
        }

        private void MnuExitClick(object sender, EventArgs e)
        {
            mManual = true;
            Close();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            if (mManual)
            {
                mNi.Visible = false;
            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            int lastinput = GetLastInputTime();
            if (lastinput >= mSeconds)
            {
                mTimer.Stop();
                var ss = new ScreenSaver();
                ss.ShowDialog();
                mTimer.Start();
            }
            Console.WriteLine(lastinput.ToString() + @"/" + mSeconds.ToString() + @" secondes");
        }


        private void StartScreenSaver()
        {
            var ss = new ScreenSaver();
            ss.WindowStartupLocation = WindowStartupLocation.Manual;
            Rectangle location = Screen.PrimaryScreen.Bounds;
            ss.WindowState = WindowState.Maximized;

            //creates window on other screens
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen == Screen.PrimaryScreen)
                    continue;

                var window = new ScreenSaver();
                window.WindowStartupLocation = WindowStartupLocation.Manual;
                location = screen.Bounds;

                //covers entire monitor
                window.Left = location.X - 7;
                window.Top = location.Y - 7;
                window.Width = location.Width + 14;
                window.Height = location.Height + 14;
            }


            ///shows primary screen window last
            ss.ShowDialog();
        }


        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Settings.Default.ImgPath = txtUrl.Text == "" ? "null" : txtUrl.Text;
            Settings.Default.PortPath = txtPort.Text == "" ? "null" : txtPort.Text;
            Settings.Default.Password = txtPassword.Text == "" ? "null" : txtPassword.Text;
            Settings.Default.Username = txtUsername.Text == "" ? "null" : txtUsername.Text;


            Settings.Default.Delay = DelaySlider.Value;

            Settings.Default.Save();

            Close();
            Application.Current.Shutdown();
        }


        private bool IsNumeric(Object expression)
        {
            if (expression == null || expression is DateTime)
                return false;

            if (expression is Int16 || expression is Int32 || expression is Int64 || expression is Decimal ||
                expression is Single || expression is Double || expression is Boolean)
                return true;

            try
            {
                if (expression is string)
                    Double.Parse(expression as string);
                else
                    Double.Parse(expression.ToString());
                return true;
            }
            catch (Exception)
            {
            } // just dismiss errors but return false
            return false;
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }

        private static int GetLastInputTime()
        {
            int idleTime = 0;
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            int envTicks = Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                int lastInputTick = Convert.ToInt32(lastInputInfo.dwTime);

                idleTime = envTicks - lastInputTick;
            }
            int toret = ((idleTime > 0) ? (idleTime/1000) : 0);

            Console.WriteLine(@"Idle time: " + idleTime.ToString());
            Console.WriteLine(toret.ToString());
            return toret;
        }

        private void DelaySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (txtDelay == null)
            {
                return;
            }


            txtDelay.Text = Convert.ToInt32(DelaySlider.Value).ToString() + "Seconds";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct LASTINPUTINFO
    {
        private static readonly int SizeOf = Marshal.SizeOf(typeof (LASTINPUTINFO));

        [MarshalAs(UnmanagedType.U4)] public int cbSize;
        [MarshalAs(UnmanagedType.U4)] public UInt32 dwTime;
    }
}