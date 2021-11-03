using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sprint_4
{
    public class SoundManager
    {
        private SoundEffect StandardJump;
        private SoundEffect SuperJump;
        private SoundEffect MarioStomp;
        private SoundEffect MarioDie;
        private SoundEffect CollectCoin;
        private SoundEffect PowerUpAppear;
        private SoundEffect GainPowerUp;
        private SoundEffect GainExtraLife;
        private SoundEffect BrickBump;
        private SoundEffect BrickBreaks;
        private SoundEffect PipeTravel;
        private SoundEffect TimeWarning;
        private SoundEffect GameOver;

        private Song BackgroundSound;

        public bool muted = false;
        public Game1 Game;

        public SoundManager(Game1 game)
        {
            Game = game;
        }


        public void LoadSounds()
        {
            BackgroundSound = Game.Content.Load<Song>("Sound/backgroundsound");
            StandardJump = Game.Content.Load<SoundEffect>("Sound/standardjump");
            SuperJump = Game.Content.Load<SoundEffect>("Sound/superjump");
            MarioStomp = Game.Content.Load<SoundEffect>("Sound/mariostomp");
            MarioDie = Game.Content.Load<SoundEffect>("Sound/mariodie");
            CollectCoin = Game.Content.Load<SoundEffect>("Sound/collectcoin");
            PowerUpAppear = Game.Content.Load<SoundEffect>("Sound/powerupappears");
            GainPowerUp = Game.Content.Load<SoundEffect>("Sound/gainpowerup");
            GainExtraLife = Game.Content.Load<SoundEffect>("Sound/gainextralife");
            BrickBump = Game.Content.Load<SoundEffect>("Sound/brickbump");
            BrickBreaks = Game.Content.Load<SoundEffect>("Sound/breakblock");
            PipeTravel = Game.Content.Load<SoundEffect>("Sound/pipetravel");
            TimeWarning = Game.Content.Load<SoundEffect>("Sound/timewarning");
            GameOver = Game.Content.Load<SoundEffect>("Sound/gameover");
        }

        public void PlayBackgroundSong()
        {
            if (!muted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(BackgroundSound);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayStandardJump()
        {
            if (!muted)
            {
                StandardJump.Play();
            }

        }

        public void PlaySuperJump()
        {
            if (!muted)
            {
                SuperJump.Play();
            }
        }


        public void PlayMarioStomp()
        {
            if (!muted)
            {
                MarioStomp.Play();
            }
        }

        public void PlayMarioDie()
        {
            if (!muted)
            {
                MediaPlayer.Stop();
                MarioDie.Play();
            }
        }

        public void PlayCollectCoin()
        {
            if (!muted)
            {
                CollectCoin.Play();
            }
        }

        public void PlayPowerUpAppear()
        {
            if (!muted)
            {
                PowerUpAppear.Play();
            }
        }

        public void PlayGainPowerUp()
        {
            if (!muted)
            {
                GainPowerUp.Play();
            }
        }

        public void PlayGainExtraLife()
        {
            if (!muted)
            {
                GainExtraLife.Play();
            }
        }


        public void PlayBrickBreaks()
        {
            if (!muted)
            {
                BrickBreaks.Play();
            }
        }

        public void PlayBirckBump()
        {
            if (!muted)
            {
                BrickBump.Play();
            }
        }

        public void PlayPipeTravel()
        {
            if (!muted)
            {
                PipeTravel.Play();
            }
        }

        public void PlayTimeWarning()
        {
            if (!muted)
            {
                TimeWarning.Play();
            }
        }
        public void PlayGameOver()
        {
            if (!muted)
            {
                MediaPlayer.Stop();
                GameOver.Play();
            }
        }

        public void MuteControl(bool mute)
        {
            if (mute)
            {
                MediaPlayer.Pause();
                muted = true;
            }
            else
            {
                MediaPlayer.Resume();
                muted = false;
            }
        }
    }
}