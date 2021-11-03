using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sprint5
{
    public class SoundManager
    {


        //SoundEffect
        private SoundEffect LaserShoot;
        private SoundEffect MachineShoot;
        private SoundEffect PistolShoot;
        private SoundEffect BossDie;
        private SoundEffect BunkerDie;
        private SoundEffect GeneralDie;
        private SoundEffect GetHurt;
        private SoundEffect GetMachine;
        private SoundEffect MachineAppear;
        private SoundEffect GetLaser;
        private SoundEffect Jump;
        //Song
        private Song Background;
        private Song Background2;
        //Other
        public Game1 Game;

        public SoundManager(Game1 game)
        {
            Game = game;
        }

        public void LoadSounds()
        {
            //Song 
            Background = Game.Content.Load<Song>("Sound/Background");
            Background2 = Game.Content.Load<Song>("Sound/Background2");
            //SoundEffect
            LaserShoot = Game.Content.Load<SoundEffect>("Sound/LaserShoot");
            MachineAppear = Game.Content.Load<SoundEffect>("Sound/MachineAppear");
            MachineShoot = Game.Content.Load<SoundEffect>("Sound/MachineShoot");
            PistolShoot = Game.Content.Load<SoundEffect>("Sound/PistolShoot");
            BossDie = Game.Content.Load<SoundEffect>("Sound/BossDie");
            BunkerDie = Game.Content.Load<SoundEffect>("Sound/BunkerDie");
            GeneralDie = Game.Content.Load<SoundEffect>("Sound/GeneralDie");
            GetHurt = Game.Content.Load<SoundEffect>("Sound/GetHurt");
            GetMachine = Game.Content.Load<SoundEffect>("Sound/GetMachine");
            GetLaser = Game.Content.Load<SoundEffect>("Sound/GetLaser");
            Jump = Game.Content.Load<SoundEffect>("Sound/Jump");

        }

        public void PlayBackgroundSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Background);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayBackgroundSong2()
        {
            MediaPlayer.Play(Background2);
        }

        public void PlayJump()
        {
            Jump.Play();
        }

        public void PlayLaserShoot()
        {
            LaserShoot.Play();
        }

        public void PlayMachineShoot()
        {
            MachineShoot.Play();
        }

        public void PlayPistolShoot()
        {
            PistolShoot.Play();
        }

        public void PlayBossDie()
        {
            BossDie.Play();
        }

        public void PlayBunkerDie()
        {
            BunkerDie.Play();
        }

        public void PlayGeneralDie()
        {
            GeneralDie.Play();
        }

        public void PlayGetHurt()
        {
            GetHurt.Play();
        }

        public void PlayGetMachine()
        {
            GetMachine.Play();
        }

        public void PlayMachineAppear()
        {
            MachineAppear.Play();
        }

        public void PlayGetLaser()
        {
            GetLaser.Play();
        }

    }
}
