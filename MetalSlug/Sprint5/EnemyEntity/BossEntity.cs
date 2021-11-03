using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    public class BossEntity : EnemyEntity
    {
        public BossEntity(Game1 game, Vector2 position, List<BulletEntity> bullets) : base(game, position, bullets)
        {
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossIdleLeft);
            EnemyWeapon = WarriorWeaponState.machineGun;
            LifePoints = 300;
            DestroyPoint = 5000;

            EnemyState = EnemyState.Idle;
            PreviousEnemyState = EnemyState;
            EnemyType = EnemyType.Boss;
            EnemyActionState = new EnemyIdleState(this);
        }

        public override void Fire()
        {
            bool isFacingLeft = this.EnemyFacing == EnemyFacing.Left;
            if (isFacingLeft)
            {
                BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Position.X, Position.Y + 20), true, BulletSource.Enemy);
                Bullets.Add(bullet);
            }
            else
            {
                BulletEntity bullet = new MachineGunBulletEntity(Game, new Vector2(Position.X + 120, Position.Y + 20), false, BulletSource.Enemy);
                Bullets.Add(bullet);
            }

            FireCD = 20;
        }
    }
}
