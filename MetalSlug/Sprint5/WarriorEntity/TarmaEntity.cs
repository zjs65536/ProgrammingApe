using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint5
{

    public class TarmaEntity : WarriorEntity
    {
        public TarmaEntity(Game1 game) : base(game)
        {
            WarriorName = WarriorName.Tarma;
            StartPosition = new Vector2(180, 200);
        }
        public override void Load()
        {
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolIdleRight);
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
