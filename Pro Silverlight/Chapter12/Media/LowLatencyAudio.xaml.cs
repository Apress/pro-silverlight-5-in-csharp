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
using System.Windows.Resources;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Threading;

namespace Media
{
    public partial class LowLatencyAudio : UserControl
    {
        public LowLatencyAudio()
        {
            InitializeComponent();
        }

        private void cmdPlaySound_Click(object sender, RoutedEventArgs e)
        {
            // Get the sound file data.
            StreamResourceInfo sri = Application.GetResourceStream(
              new Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute));

            // Load the sound. 
            SoundEffect explosionSound = SoundEffect.FromStream(sri.Stream);

            // Play the sound. This happens asynchronously, so the code carries on
            // with no pause.
            explosionSound.Play();
        }

        private void cmdPlayModifiedSound_Click(object sender, RoutedEventArgs e)
        {
            // Get the sound file data.
            StreamResourceInfo sri = Application.GetResourceStream(
              new Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute));

            // Load the sound. 
            SoundEffect explosionSound = SoundEffect.FromStream(sri.Stream);

            // Play the sound. This happens asynchronously, so the code carries on
            // with no pause.
            explosionSound.Play(0.8f, 1.0f, -0.3f);
        }

        private void cmdPlayMultipleSounds_Click(object sender, RoutedEventArgs e)
        {
            // Get the sound file data.
            StreamResourceInfo sri = Application.GetResourceStream(
              new Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute));

            // Load the sound. 
            SoundEffect explosionSound = SoundEffect.FromStream(sri.Stream);
                        
            SoundEffectInstance explosion1 = explosionSound.CreateInstance();
            SoundEffectInstance explosion2 = explosionSound.CreateInstance();
            
            // explosion1 will be a lower, quieter sound.
            explosion1.Pitch = -0.5f;
            explosion1.Volume = 0.8f;

            // explosion2 will be panned to one side, higher-pitched, and even quieter.
            explosion1.Pitch = 1.5f;
            explosion2.Pan = -0.9f;
            explosion2.Volume = 0.7f;

            // Play all three at once.
            explosionSound.Play();
            explosion1.Play();
            explosion2.Play();
        }

        private void cmdPlayStaggeredSounds_Click(object sender, RoutedEventArgs e)
        {
            // Get the sound file data.
            StreamResourceInfo sri = Application.GetResourceStream(
              new Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute));

            // Load the sound. 
            SoundEffect explosionSound = SoundEffect.FromStream(sri.Stream);
                        
            SoundEffectInstance explosion1 = explosionSound.CreateInstance();
            SoundEffectInstance explosion2 = explosionSound.CreateInstance();
            
            // explosion1 will be a lower, quieter sound.
            explosion1.Pitch = -0.5f;
            explosion1.Volume = 0.8f;

            // explosion2 will be panned to one side, and even quieter.
            explosion2.Pan = -0.9f;
            explosion2.Volume = 0.7f;                       

            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(0.5);
            // Play the second sound half a second later.
            timer1.Tick += delegate
            {
                timer1.Stop();
                explosion1.Play();
            };

            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            // Play the third sound a second later.
            timer2.Tick += delegate
            {
                timer2.Stop();
                explosion2.Play();
            };

            // Play the first sound.
            explosionSound.Play();
            
            // Queue the next sounds.            
            timer1.Start();
            timer2.Start();
        }

        private SoundEffectInstance backgroundInstance;
        private void cmdStartLoop_Click(object sender, RoutedEventArgs e)
        {
            // Get the sound file data.
            StreamResourceInfo sri = Application.GetResourceStream(
              new Uri("Media;component/explosion.wav", UriKind.RelativeOrAbsolute));

            SoundEffect backgroundEffect = SoundEffect.FromStream(sri.Stream);
            backgroundInstance = backgroundEffect.CreateInstance();

            backgroundInstance.IsLooped = true;
            backgroundInstance.Play();
        }

        private void cmdStopLoop_Click(object sender, RoutedEventArgs e)
        {
            if (backgroundInstance != null) {
                backgroundInstance.Stop();
                backgroundInstance = null;
            }
        }
    }
}
