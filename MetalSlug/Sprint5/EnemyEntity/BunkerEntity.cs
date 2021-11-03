using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class BunkerEntity : EnemyEntity
    {
        public BunkerEntity(Game1 game, Vector2 position, List<BulletEntity> bullets) : base(game, position, bullets)
        {
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerIdleLeft);
            EnemyWeapon = WarriorWeaponState.lazerGun;
            LifePoints = 100;
            DestroyPoint = 1000;

            EnemyState = EnemyState.Idle;
            PreviousEnemyState = EnemyState;
            EnemyType = EnemyType.Bunker;
            EnemyActionState = new EnemyIdleState(this);
        }

        public override void Fire()
        {
            bool isFacingLeft = this.EnemyFacing == EnemyFacing.Left;
            if (isFacingLeft)
            {
                BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Position.X, Position.Y + 20), true, BulletSource.Enemy);
                Bullets.Add(bullet);
            }
            else
            {
                BulletEntity bullet = new LaserGunBulletEntity(Game, new Vector2(Position.X + 80, Position.Y + 20), false, BulletSource.Enemy);
                Bullets.Add(bullet);
            }

            FireCD = 60;
        }
    }
}
