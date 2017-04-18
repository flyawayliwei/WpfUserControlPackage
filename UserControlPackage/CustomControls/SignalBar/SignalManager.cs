using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace UserControlPackage.CustomControls.SignalBar
{
    class SignalManager : DependencyObject
    {
        public static SignalManager Instance { get { return instance; } }

        public int RandomA
        {
            get { return (int)GetValue(RandomAProperty); }
            set { SetValue(RandomAProperty, value); }
        }

        SignalManager()
        {
            InitializationTimer();
        }

        public void Start()
        {
            if (!timerA.Enabled) timerA.Start();
        }

        public void Stop()
        {
            if (timerA.Enabled) timerA.Stop();
        }

        private void InitializationTimer()
        {
            timerA = new Timer();
            timerA.Interval = INTERVAL;
            timerA.Elapsed += timerA_Elapsed;
        }

        void timerA_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                RandomA = a.Next(MAX_VALUE);
            }));
        }

        public static readonly DependencyProperty RandomAProperty =
            DependencyProperty.Register("RandomA", typeof(int), typeof(SignalManager), new PropertyMetadata(0));

        private Random a = new Random((int)DateTime.Now.Ticks);
        private const int MAX_VALUE = 100;
        private const double INTERVAL = 1000;
        private Timer timerA;
        private static SignalManager instance = new SignalManager();
    }
}
