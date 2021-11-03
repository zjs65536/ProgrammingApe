using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class MachineGunEntity : WeaponEntity
    {
        private Game1 Game;
        
        public MachineGunEntity(Game1 game, Vector2 position) : base(game, position)
        {
            Game = game;
            AmmoNum = 20;

            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MachineGun);
            WeaponType = WarriorWeaponState.machineGun;
        }
    }
}
