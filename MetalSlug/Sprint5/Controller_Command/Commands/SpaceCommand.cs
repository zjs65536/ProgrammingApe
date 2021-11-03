
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint5
{
    public class SpaceCommand : ICommand
    {
        private Game1 Game;
        private WarriorEntity Warrior;
        private List<BulletEntity> Bullets;
        public SpaceCommand(Game1 game, WarriorEntity warriorEntity, List<BulletEntity> bullets)
        {
            Game = game;
            Warrior = warriorEntity;
            Bullets = bullets;
        }

        public void Execute()
        {
            if(Warrior.FireCD == 0 && Warrior.WarriorState == WarriorState.Stand)
            {
                if (Warrior.WarriorFacing == WarriorFacing.Left)
                {
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.Pistal)
                    {
                        BulletEntity bullet = new PistolBulletEntity(Game, new Vector2(Warrior.Position.X, Warrior.Position.Y + 24), true, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayPistolShoot();
                    }
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.machineGun)
                    {
                        BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Warrior.Position.X, Warrior.Position.Y + 24), true, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayMachineShoot();
                    }
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.lazerGun)
                    {
                        BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Warrior.Position.X, Warrior.Position.Y + 24), true, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayLaserShoot();
                    }
                }
                else
                {
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.Pistal)
                    {
                        BulletEntity bullet = new PistolBulletEntity(Game, new Vector2(Warrior.Position.X + 36, Warrior.Position.Y + 24), false, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayPistolShoot();
                    }
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.machineGun)
                    {
                        BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Warrior.Position.X + 36, Warrior.Position.Y + 24), false, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayMachineShoot();
                    }
                    if (Warrior.WarriorWeaponState == WarriorWeaponState.lazerGun)
                    {
                        BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Warrior.Position.X + 36, Warrior.Position.Y + 24), false, BulletSource.Marco);
                        Bullets.Add(bullet);
                        Game.SoundManager.PlayLaserShoot();
                    }
                }
                Warrior.FireCD = 25;
                if (Warrior.WeaponAmmo > 0)
                    Warrior.WeaponAmmo--;
            }
            if (Warrior.WeaponAmmo == 0)
                Warrior.WarriorWeaponState = WarriorWeaponState.Pistal;
        }
    }
}
