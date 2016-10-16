using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Media
{
    public partial class MediaCommands : UserControl
    {
        public MediaCommands()
        {
            InitializeComponent();
        }

        private void media_MediaCommand(object sender, MediaCommandEventArgs e)
        {
            if (e.MediaCommand == System.Windows.Media.MediaCommand.Play)
            {
                media.Play();
            }       
            else if (e.MediaCommand == System.Windows.Media.MediaCommand.Pause)
            {
                media.Pause();
            }
            else if (e.MediaCommand == System.Windows.Media.MediaCommand.TogglePlayPause)
            {
                if (media.CurrentState == MediaElementState.Paused || media.CurrentState == MediaElementState.Stopped)
                {
                    media.Play();
                }
                else if (media.CurrentState == MediaElementState.Playing)
                {
                    media.Pause();
                }
            }
            else if (e.MediaCommand == System.Windows.Media.MediaCommand.IncreaseVolume)
            {
                media.Volume += .1;
            }
            else if (e.MediaCommand == System.Windows.Media.MediaCommand.DecreaseVolume)
            {
                media.Volume -= .1;
            } 
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
            media.Play();
        }

        private void cmdFullScreen_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
        }        
    }
}
