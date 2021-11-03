using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class CaptainEntity : EnemyEntity
    {
        public CaptainEntity(Game1 game, Vector2 position, List<BulletEntity> bullets) : base(game, position, bullets)
        {
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainRunLeft);
            EnemyWeapon = WarriorWeaponState.machineGun;
            LifePoints = 75;
            DestroyPoint = 250;
            Velocity = new Vector2(-50f, 0);

            EnemyState = EnemyState.Run;
            PreviousEnemyState = EnemyState;
            EnemyType = EnemyType.Captain;
            EnemyActionState = new EnemyRunState(this);
        }

        public override void Fire()
        {
            bool isFacingLeft = this.EnemyFacing == EnemyFacing.Left;
            if (isFacingLeft)
            {
                BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Position.X, Position.Y + 10), true, BulletSource.Enemy);
                Bullets.Add(bullet);
            }
            else
            {
                BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Position.X + 40, Position.Y + 10), false, BulletSource.Enemy);
                Bullets.Add(bullet);
            }

            FireCD = 50;
        }
    }
}
