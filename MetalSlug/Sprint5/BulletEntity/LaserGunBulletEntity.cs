using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class LaserGunBulletEntity : BulletEntity
    {
        private Game1 Game;
        public LaserGunBulletEntity(Game1 game, Vector2 position, bool isFacingLeft, BulletSource bulletSource) : base(game, position, isFacingLeft, bulletSource)
        {
            Game = game;
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.LaserGunBullet);
            if (IsFacingLeft)
                Velocity = new Vector2(-300f, 0);
            else
                Velocity = new Vector2(300f, 0);
            Damage = 40;
            LifeSpan = 150;
            BulletEnum = BulletEnum.LaserGunBullet;
        }
    }
}
