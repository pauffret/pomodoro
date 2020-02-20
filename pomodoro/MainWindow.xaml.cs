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
        SoundPlayer beepSound = new SoundPlayer(Properties.Resources.beep06);
        SoundPlayer uefaSound = new SoundPlayer(Properties.Resources.uefa);
        SoundPlayer policeSound = new SoundPlayer(Properties.Resources.police);
        int statement = 1;
        int nbSession = 0;

        public MainWindow()
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(5);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lbl_time.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    beepSound.Play();
                    if (statement == 0)
                    {
                        _time = TimeSpan.FromSeconds(5);
                        btn_start.Content = "Démarer la session";
                        nbSession += 1;
                        statement = 1;
                        Console.WriteLine("start" + nbSession);
                    }
                    else
                    {
                        statement = 0;
                        btn_start.Content = "Démarer la pause";
                        if (nbSession == 3)
                        {
                            _time = TimeSpan.FromSeconds(4);
                            Console.WriteLine("longPause");
                        }
                        else
                        {
                            _time = TimeSpan.FromSeconds(2);
                            Console.WriteLine("pause");
                        }
                    }
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

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            lbx_historiqueSession.Items.Add(tbx_tagSession.Text);
            tbx_tagSession.Text = "";
        }

        private void tbx_tagSession__TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private int getNbPomodoro()
        {
            int nbPomodoros = 0;
            foreach (var item in lbx_historiqueSession.Items)
            {
                nbPomodoros += 1;
            }
            return nbPomodoros;
        }

    }
}
