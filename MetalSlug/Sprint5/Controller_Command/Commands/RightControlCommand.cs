using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint5
{
    public class RightControlCommand : ICommand
    {
        private Game1 Game;
        private WarriorEntity Tarma;
        private List<BulletEntity> Bullets;
        public RightControlCommand(Game1 game, WarriorEntity tarmaEntity, List<BulletEntity> bullets)
        {
            Game = game;
            Tarma = tarmaEntity;
            Bullets = bullets;
        }

        public void Execute()
        {
            if(Tarma.FireCD == 0 && Tarma.WarriorState == WarriorState.Stand)
            {
                if (Tarma.WarriorFacing == WarriorFacing.Left)
                {
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.Pistal)
                    {
                        BulletEntity bullet = new PistolBulletEntity(Game, new Vector2(Tarma.Position.X, Tarma.Position.Y + 24), true, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayPistolShoot();
                    }
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.machineGun)
                    {
                        BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Tarma.Position.X, Tarma.Position.Y + 24), true, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayMachineShoot();
                    }
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.lazerGun)
                    {
                        BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Tarma.Position.X, Tarma.Position.Y + 24), true, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayLaserShoot();
                    }
                }
                else
                {
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.Pistal)
                    {
                        BulletEntity bullet = new PistolBulletEntity(Game, new Vector2(Tarma.Position.X + 36, Tarma.Position.Y + 24), false, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayPistolShoot();
                    }
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.machineGun)
                    {
                        BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Tarma.Position.X + 36, Tarma.Position.Y + 24), false, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayMachineShoot();
                    }
                    if (Tarma.WarriorWeaponState == WarriorWeaponState.lazerGun)
                    {
                        BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Tarma.Position.X + 36, Tarma.Position.Y + 24), false, BulletSource.Tarma);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayLaserShoot();
                    }
                }
                Tarma.FireCD = 25;
                if (Tarma.WeaponAmmo > 0)
                    Tarma.WeaponAmmo--;
            }
            if (Tarma.WeaponAmmo == 0)
                Tarma.WarriorWeaponState = WarriorWeaponState.Pistal;
        }
    }
}