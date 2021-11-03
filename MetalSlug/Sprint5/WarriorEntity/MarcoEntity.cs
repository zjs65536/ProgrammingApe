using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint5
{
    public class MarcoEntity : WarriorEntity
    {
        public MarcoEntity(Game1 game) : base(game)
        {
            WarriorName = WarriorName.Marco;
            StartPosition = new Vector2(90, 200);
        }
        public override void Load()
        {
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolIdleRight);
            WarriorState = WarriorState.Stand;
            WarriorWeaponState = WarriorWeaponState.Pistal;
            WarriorFacing = WarriorFacing.Right;
            previousWarriorState = WarriorState;
            previosWarriorWeaponState = WarriorWeaponState;
            previousWarriorFacing = WarriorFacing;
            base.Load();
        }
    }
}
