using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class MachineGunBulletEntity : BulletEntity
    {
        private Game1 Game;
        public MachineGunBulletEntity(Game1 game, Vector2 position, bool isFacingLeft, BulletSource bulletSource) : base(game, position, isFacingLeft, bulletSource)
        {
            Game = game;
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MachineGunBullet);
            if (IsFacingLeft)
                Velocity = new Vector2(-150f, 0);
            else
                Velocity = new Vector2(150f, 0);
            Damage = 25;
            LifeSpan = 200;
            BulletEnum = BulletEnum.MachineGunBullet;
        }
    }
}
