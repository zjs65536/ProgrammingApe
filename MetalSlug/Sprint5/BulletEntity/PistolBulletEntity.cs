using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class PistolBulletEntity : BulletEntity
    {
        private Game1 Game;
        public PistolBulletEntity(Game1 game, Vector2 position, bool isFacingLeft, BulletSource bulletSource) : base(game, position, isFacingLeft, bulletSource)
        {
            Game = game;
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.PistolBullet);
            if (IsFacingLeft)
                Velocity = new Vector2(-100f, 0);
            else
                Velocity = new Vector2(100f, 0);
            Damage = 10;
            LifeSpan = 200;
            BulletEnum = BulletEnum.PistolBullet;
        }
    }
}
