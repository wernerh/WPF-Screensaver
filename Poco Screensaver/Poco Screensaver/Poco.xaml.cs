using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Poco_Screensaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Poco : Window
    {

        #region Properties

        public bool _IsActive { get; set; }

        public Point _MousePosition { get; set; }

        #endregion

        #region Constructor

        public Poco()
        {
            InitializeComponent();
            
            this.MouseMove += new MouseEventHandler(Poco_MouseMove);
            this.KeyDown += new KeyEventHandler(Poco_KeyDown);
        }

        #endregion

        #region Private Methods

        private void Poco_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.MouseDevice.GetPosition(this);
            // Set IsActive and MouseLocation only the first time this event is called.
            if (!_IsActive)
            {
                _MousePosition = currentPosition;
                _IsActive = true;
            }
            else
            {
                // If the mouse has moved significantly since first call, close.
                if ((Math.Abs(_MousePosition.X - currentPosition.X) > 10) ||
                    (Math.Abs(_MousePosition.Y - currentPosition.Y) > 10))
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void Poco_KeyDown(object sender, KeyEventArgs e)
        {
           Application.Current.Shutdown();
        }

        #endregion
    }
}
