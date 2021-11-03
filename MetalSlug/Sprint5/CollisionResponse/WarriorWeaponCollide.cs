using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WarriorWeaponCollide
    {
        private Game1 Game;

        public WarriorWeaponCollide(Game1 game)
        {
            Game = game;
        }

        public void WarriorWeaponCollideResponse(WarriorEntity warrior, WeaponEntity weapon)
        {
            weapon.isDestroyed = true;
            if (weapon.WeaponType == WarriorWeaponState.machineGun)
            {
                warrior.WarriorWeaponState = WarriorWeaponState.machineGun;
                Game.SoundManager.PlayGetMachine();
                if (warrior.WarriorName == WarriorName.Marco)
                    Game.GameHUD.MarcoPoint += 100;
                else
                    Game.GameHUD.TarmaPoint += 100;
            }
            else
            {
                warrior.WarriorWeaponState = WarriorWeaponState.lazerGun;
                Game.SoundManager.PlayGetLaser();
                if (warrior.WarriorName == WarriorName.Marco)
                    Game.GameHUD.MarcoPoint += 200;
                else
                    Game.GameHUD.TarmaPoint += 200;
            }
            warrior.WeaponAmmo = weapon.AmmoNum;
        }
    }
}
