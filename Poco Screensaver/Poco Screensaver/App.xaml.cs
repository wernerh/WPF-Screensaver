using System.Globalization;
using System.Windows;

namespace Poco_Screensaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string[] args = e.Args;

            if (args.Length > 0)
            {
                string arg = args[0].ToLower(CultureInfo.InvariantCulture).Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/c":
                        // This screensaver has no options you can configure
                        MessageBox.Show("This screensaver has no options you can configure.", "Screensaver", MessageBoxButton.OK, MessageBoxImage.Information);
                        Application.Current.Shutdown();
                        break;
                    case "/p":
                        // Don't do anything for preview
                        Application.Current.Shutdown();
                        break;
                    case "/s":
                        // Show screensaver form
                        ShowScreensaver();
                        break;
                    default:
                        Application.Current.Shutdown();
                        break;
                }
            }
            else
            {
                // If no arguments were passed in, show the screensaver
                ShowScreensaver();
            }
        }

        void ShowScreensaver()
        {
            //creates window on primary screen
            var primaryWindow = new Poco();
            //var primaryWindow = new DigitalClock();
            primaryWindow.Show();       
        }
    }
}

