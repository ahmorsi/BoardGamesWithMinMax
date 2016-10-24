using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMPLib;

namespace BoardGameProject
{
    class Sound
    {
        private static bool MusicStat = true, EffectState = true;

        public static WindowsMediaPlayer player = new WindowsMediaPlayer();
        public static WindowsMediaPlayer Hover = new WindowsMediaPlayer();
        public static WindowsMediaPlayer Unit = new WindowsMediaPlayer();
        public static WindowsMediaPlayer Chalk = new WindowsMediaPlayer();

        public static void setSound()
        {
            player.settings.playCount = 1000;
            player.URL = "Music.mp3";
            Hover.URL = "Hover.wav";
            Chalk.URL = "Chalk.wav";
            Unit.URL = "Unit.wav";

            Hover.controls.stop();
            Chalk.controls.stop();
            Unit.controls.stop();
        }

        public static void playMusic()
        {
            player.controls.play();
            MusicStat = true;
        }

        public static void stopMusic()
        {
            player.controls.pause();
            MusicStat = false;
        }

        public static void playHover()
        {
            if (EffectState)
                Hover.controls.play();
        }

        public static void playChalk()
        {
            if (EffectState)
                Chalk.controls.play();
        }

        public static void playUnit()
        {
            if (EffectState)
                Unit.controls.play();
        }

        public static bool getEffectsStatus()
        {
            return EffectState;
        }

        public static void playEffects()
        {
            EffectState = true;
        }

        public static void stopEffects()
        {
            EffectState = false;
        }

        public static bool getBackMusicStatus()
        {
            return MusicStat;
        }

        public static bool getBackEffectsStatus()
        {
            return EffectState;
        }
    }
}
