using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Poco_Screensaver
{

    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : Window
    {

        #region Fields

        private Timer _timer = new Timer(1000);

        #endregion

        #region Properties

        public bool _IsActive { get; set; }

        public Point _MousePosition { get; set; }

        #endregion
  
        #region Constructor

        public DigitalClock()
        {
            InitializeComponent();

            SetTime();

            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);       
            _timer.Start();

            this.MouseMove += new MouseEventHandler(DigitalClock_MouseMove);
            this.KeyDown += new KeyEventHandler(DigitalClock_KeyDown);
        }

        #endregion

        #region Private Methods

        private void SetTime()
        {
            timeText.Content = DateTime.Now.ToLongTimeString();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(SetTime));
        }

        private void DigitalClock_MouseMove(object sender, MouseEventArgs e)
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

        private void DigitalClock_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion    
    }
}
