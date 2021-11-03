using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class SpriteFactory
    {
        private Game1 Game;
        private GraphicsDevice GraphicsDevice;

        private Texture2D CurrentSprite;

        public SpriteFactory(Game1 game, GraphicsDevice graphicsDevice)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
        }

        public enum Sprites
        {
            // Marco
            MarcoPistolIdleLeft, MarcoPistolIdleRight, MarcoPistolRunLeft, MarcoPistolRunRight, MarcoPistolCrouchLeft, MarcoPistolCrouchRight, MarcoJumpLeft, MarcoJumpRight, MarcoDie, MarcoCelebrate,
            MarcoMachineGunIdleLeft, MarcoMachineGunIdleRight, MarcoMachineGunRunLeft, MarcoMachineGunRunRight, MarcoMachineGunCrouchLeft, MarcoMachineGunCrouchRight,
            MarcoLaserGunIdleLeft, MarcoLaserGunIdleRight, MarcoLaserGunRunLeft, MarcoLaserGunRunRight, MarcoLaserGunCrouchLeft, MarcoLaserGunCrouchRight,
            // Tarma
            TarmaPistolIdleLeft, TarmaPistolIdleRight, TarmaPistolRunLeft, TarmaPistolRunRight, TarmaPistolCrouchLeft, TarmaPistolCrouchRight, TarmaJumpLeft, TarmaJumpRight, TarmaDie, TarmaCelebrate,
            TarmaMachineGunIdleLeft, TarmaMachineGunIdleRight, TarmaMachineGunRunLeft, TarmaMachineGunRunRight, TarmaMachineGunCrouchLeft, TarmaMachineGunCrouchRight,
            TarmaLaserGunIdleLeft, TarmaLaserGunIdleRight, TarmaLaserGunRunLeft, TarmaLaserGunRunRight, TarmaLaserGunCrouchLeft, TarmaLaserGunCrouchRight,
            // Soldier
            SoldierRunLeft, SoldierRunRight, SoldierDie, SoldierFireLeft, SoldierFireRight,
            // Captain
            CaptainRunLeft, CaptainRunRight, CaptainDie, CaptainFireLeft, CaptainFireRight,
            // Bunker
            BunkerIdleLeft, BunkerIdleRight, BunkerFireLeft, BunkerFireRight, BunkerDie,
            // Boss
            BossIdleLeft, BossIdleRight, BossFireLeft, BossFireRight, BossDie,
            // Weapon
            MachineGun, LaserGun,
            // Bullet
            PistolBullet, MachineGunBullet, LaserGunBullet,
            // Block
            StoneBlock, WoodenBox,
            // Background
            Background,
            // HealthBar
            RedHealthBar, YellowHealthBar, GreenHealthBar
        }

        public ISprite CreateSprite(SpriteFactory.Sprites sprite)
        {
            // Marco
            if(sprite == Sprites.MarcoPistolIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoPistolIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoPistolRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 9);
            }
            if (sprite == Sprites.MarcoPistolRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolRunRight");
                return new WarriorSprite(CurrentSprite, 1, 9);
            }
            if (sprite == Sprites.MarcoPistolCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoPistolCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoPistolCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoMachineGunIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoMachineGunIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoMachineGunRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 11);
            }
            if (sprite == Sprites.MarcoMachineGunRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunRunRight");
                return new WarriorSprite(CurrentSprite, 1, 11);
            }
            if (sprite == Sprites.MarcoMachineGunCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoMachineGunCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoMachineGunCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoLaserGunIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoLaserGunIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoLaserGunRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.MarcoLaserGunRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunRunRight");
                return new WarriorSprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.MarcoLaserGunCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoLaserGunCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoLaserGunCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoJumpLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoJumpLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoJumpRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoJumpRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoDead");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MarcoCelebrate)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Marco/MarcoCelebrate");
                return new WarriorSprite(CurrentSprite, 1, 4);
            }

            // Tarma
            if (sprite == Sprites.TarmaPistolIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaPistolIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaPistolRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaPistolRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolRunRight");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaPistolCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaPistolCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaPistolCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaMachineGunIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaMachineGunIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaMachineGunRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaMachineGunRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunRunRight");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaMachineGunCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaMachineGunCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaMachineGunCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaLaserGunIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunIdleLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaLaserGunIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunIdleRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaLaserGunRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunRunLeft");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaLaserGunRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunRunRight");
                return new WarriorSprite(CurrentSprite, 1, 6);
            }
            if (sprite == Sprites.TarmaLaserGunCrouchLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunCrouchLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaLaserGunCrouchRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaLaserGunCrouchRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaJumpLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaJumpLeft");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaJumpRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaJumpRight");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaDead");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.TarmaCelebrate)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Tarma/TarmaCelebrate");
                return new WarriorSprite(CurrentSprite, 1, 4);
            }

            // Soldier
            if (sprite == Sprites.SoldierRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Soldier/SoldierRunLeft");
                return new EnemySprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.SoldierRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Soldier/SoldierRunRight");
                return new EnemySprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.SoldierDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Soldier/SoldierDie");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.SoldierFireLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Soldier/SoldierFireLeft");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.SoldierFireRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Soldier/SoldierFireRight");
                return new EnemySprite(CurrentSprite, 1, 1);
            }

            // Captain
            if (sprite == Sprites.CaptainRunLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Captain/CaptainRunLeft");
                return new EnemySprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.CaptainRunRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Captain/CaptainRunRight");
                return new EnemySprite(CurrentSprite, 1, 12);
            }
            if (sprite == Sprites.CaptainDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Captain/CaptainDie");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.CaptainFireLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Captain/CaptainFireLeft");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.CaptainFireRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Captain/CaptainFireRight");
                return new EnemySprite(CurrentSprite, 1, 1);
            }

            // Bunker
            if (sprite == Sprites.BunkerIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bunker/BunkerIdleLeft");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BunkerIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bunker/BunkerIdleRight");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BunkerFireLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bunker/BunkerIdleLeft"); //
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BunkerFireRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bunker/BunkerIdleRight"); //
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BunkerDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bunker/BunkerDead");
                return new EnemySprite(CurrentSprite, 1, 1);
            }

            // Boss
            if (sprite == Sprites.BossIdleLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Boss/BossIdleLeft");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BossIdleRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Boss/BossIdleRight");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BossFireLeft)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Boss/BossFireLeft");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BossFireRight)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Boss/BossFireRight");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.BossDie)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Boss/BossDead");
                return new EnemySprite(CurrentSprite, 1, 1);
            }

            // Weapon
            if (sprite == Sprites.MachineGun)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Weapon/MachineGun");
                return new WeaponSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.LaserGun)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Weapon/LaserGun");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }

            // Bullet
            if (sprite == Sprites.PistolBullet)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bullet/PistolBullet");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.MachineGunBullet)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bullet/MachineGunBullet");
                return new EnemySprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.LaserGunBullet)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Bullet/LaserGunBullet");
                return new EnemySprite(CurrentSprite, 1, 1);
            }

            // Block
            if (sprite == Sprites.StoneBlock)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Block/StoneBlock");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.WoodenBox)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Block/WoodenBox");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }

            // Background
            if(sprite == Sprites.Background)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("Background/Background1");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }

            // HealthBar
            if (sprite == Sprites.GreenHealthBar)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("HealthBar/GreenHealthBar");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.YellowHealthBar)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("HealthBar/YellowHealthBar");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            if (sprite == Sprites.RedHealthBar)
            {
                CurrentSprite = Game.Content.Load<Texture2D>("HealthBar/RedHealthBar");
                return new WarriorSprite(CurrentSprite, 1, 1);
            }
            return null;
        }
    }
}
