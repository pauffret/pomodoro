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
        int statement = 0;
        int nbSession = 0;
        int pause = 0;

        public MainWindow()
        {
            InitializeComponent();
            getTimer();
        }

        private void getTimer()
        {
            if (nbSession < getNbPomodoro())
            {
                if (statement == 0)
                {
                    _time = TimeSpan.FromSeconds(5);
                    lbl_titre.Content = "Travail";
                    // TODO afficher le tag de la session dans lbl_indication
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
                        _time = TimeSpan.FromSeconds(4);
                    }
                    else
                    {
                        _time = TimeSpan.FromSeconds(2);
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
                // TODO les sessions s'enchaine bien si on les ajoutent au début mais si on en rajoute une
                // après avoir lancé le timer une fois le timer bug
                // Je pense que c'est à cause du _timer.Start() qui est le seul a lancé le timer sans définir une durée au début
                // mais je ne comprend pas pourquoi vu qu'il ne devrait pas passé sans qu'une pause est été faite avant
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
