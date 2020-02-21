using System;
using System.Collections;
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
        int statement = 0;
        int nbSession = 0;
        int pause = 0;
        ArrayList sessionList = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
            getTimer();
        }

        private void getTimer()
        {
            foreach(String session in sessionList) { }
            if (nbSession < getNbPomodoro())
            {
                if (statement == 0)
                {
                    _time = TimeSpan.FromSeconds(1500);
                    lbl_titre.Content = "Travail #"+(nbSession+1);
                    // TODO afficher le tag de la session dans lbl_indication
                    int countSession = lbx_historiqueSession.Items.Count;
                    lbl_indication.Content = "";
                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                    lbl_time.Content = _time.ToString("c").Substring(3, 5);
                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        beepSound.Play();
                        statement = 1;
                        lbl_indication.Content = "Appuyer sur Start pour démarrer la pause";
                    }
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                    }, Application.Current.Dispatcher);
                }
                else
                {
                    lbl_titre.Content = "Pause";
                    lbl_indication.Content = "";
                    if (nbSession == 3)
                    {
                        _time = TimeSpan.FromSeconds(900);
                    }
                    else
                    {
                        _time = TimeSpan.FromSeconds(300);
                    }
                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                        lbl_time.Content = _time.ToString("c").Substring(3, 5);
                        if (_time == TimeSpan.Zero)
                        {
                            _timer.Stop();
                            beepSound.Play();
                            nbSession += 1;
                            statement = 0;
                            if (nbSession < getNbPomodoro())
                            {
                                lbl_indication.Content = "Appuyer sur Start pour démarrer la session suivante";
                            }
                            else
                            {
                                lbl_indication.Content = "Vous devez ajouter une nouvelle session dans les paramètres";
                            }
                        }
                        _time = _time.Add(TimeSpan.FromSeconds(-1));
                    }, Application.Current.Dispatcher);
                }
            }
            else
            {
                lbl_indication.Content = "Vous devez ajouter une nouvelle session dans les paramètres";
            }
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (nbSession < getNbPomodoro() & getNbPomodoro() != 0)
            {

                if (_timer != null & pause == 1)
                {
                    _timer.Start();
                    pause = 0;
                }
                else
                {
                    getTimer();
                }
            }
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            if (getNbPomodoro() != 0)
            {
                _timer.Stop();
                pause = 1;
            }
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_tagSession.Text != "")
            {
                lbx_historiqueSession.Items.Add(tbx_tagSession.Text);
                sessionList.Add(tbx_tagSession.Text);
            }
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
