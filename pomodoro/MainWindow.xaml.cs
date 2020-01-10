using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pomodoro
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        SoundPlayer simpleSound = new SoundPlayer(@"D:\EPSI\.NET\Projets\pomodoro\bip\beep-06.wav");

        public MainWindow()
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(2);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lbl_time.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero){
                    _timer.Stop();
                    simpleSound.Play();
                    _time = TimeSpan.FromSeconds(300);
                    _timer.Start();
                    simpleSound.Play();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Stop();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            _time = new TimeSpan();
            _time = TimeSpan.FromSeconds(1500);
            lbl_time.Content = _time.ToString("c");
        }

        private void tbx_nbSession__TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
