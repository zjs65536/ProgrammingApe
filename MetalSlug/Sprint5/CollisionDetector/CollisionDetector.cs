using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class CollisionDetector
    {
        public Game1 Game;

        public BulletBlockCollide BulletBlockCollide;
        public EnemyBlockCollide EnemyBlockCollide;
        public EnemyBulletCollide EnemyBulletCollide;
        public WarriorBlockCollide WarriorBlockCollide;
        public WarriorBulletCollide WarriorBulletCollide;
        public WarriorEnemyCollide WarriorEnemyCollide;
        public WarriorWeaponCollide WarriorWeaponCollide;
        public WeaponBlockCollide WeaponBlockCollide;
        
        public CollisionDetector(Game1 game)
        {
            Game = game;

            BulletBlockCollide = new BulletBlockCollide(game);
            EnemyBlockCollide = new EnemyBlockCollide(game);
            EnemyBulletCollide = new EnemyBulletCollide(game);
            WarriorBlockCollide = new WarriorBlockCollide(game);
            WarriorBulletCollide = new WarriorBulletCollide(game);
            WarriorEnemyCollide = new WarriorEnemyCollide(game);
            WarriorWeaponCollide = new WarriorWeaponCollide(game);
            WeaponBlockCollide = new WeaponBlockCollide(game);
        }
        
        public void CollisionDetect(WarriorEntity marco, WarriorEntity tarma, List<BlockEntity> blocks, List<EnemyEntity> enemies, List<WeaponEntity> weapons, List<BulletEntity> bullets)
        {
            Rectangle MarcoRectangle = marco.GetBoundaryBox();
            Rectangle TarmaRectangle = tarma.GetBoundaryBox();
            foreach (BlockEntity block in blocks.ToList())
            {
                Rectangle BlockRectangle = block.GetBoundaryBox();
                if(MarcoRectangle.Intersects(BlockRectangle))
                {
                    WarriorBlockCollide.WarriorBlockCollideResponse(marco, block);
                }
                if(TarmaRectangle.Intersects(BlockRectangle))
                {
                    WarriorBlockCollide.WarriorBlockCollideResponse(tarma, block);
                }

                foreach (EnemyEntity enemy in enemies.ToList())
                {
                    Rectangle EnemyRectangle = enemy.GetBoundaryBox();
                    if(EnemyRectangle.Intersects(BlockRectangle))
                    {
                        EnemyBlockCollide.EnemyBlockCollideResponse(enemy, block);
                    }

                    if (MarcoRectangle.Intersects(EnemyRectangle))
                    {
                        WarriorEnemyCollide.WarriorEnemyCollideResponse(marco, enemy);
                    }
                    if (TarmaRectangle.Intersects(EnemyRectangle))
                    {
                        WarriorEnemyCollide.WarriorEnemyCollideResponse(tarma, enemy);
                    }
                }

                foreach (BulletEntity bullet in bullets.ToList())
                {
                    Rectangle BulletRectangle = bullet.GetBoundaryBox();
                    if(BulletRectangle.Intersects(BlockRectangle))
                    {
                        BulletBlockCollide.BulletBlockCollideResponse(bullet, block);
                    }
                }

                foreach (WeaponEntity weapon in weapons.ToList())
                {
                    Rectangle WeaponRectangle = weapon.GetBoundaryBox();
                    if(WeaponRectangle.Intersects(BlockRectangle))
                    {
                        WeaponBlockCollide.WeaponBlockCollideResponse(weapon, block);
                    }

                    if(WeaponRectangle.Intersects(MarcoRectangle))
                    {
                        WarriorWeaponCollide.WarriorWeaponCollideResponse(marco, weapon);
                    }
                    if(WeaponRectangle.Intersects(TarmaRectangle))
                    {
                        WarriorWeaponCollide.WarriorWeaponCollideResponse(tarma, weapon);
                    }
                }
            }

            foreach (BulletEntity bullet in bullets.ToList())
            {
                Rectangle BulletRectangle = bullet.GetBoundaryBox();
                foreach (EnemyEntity enemy in enemies.ToList())
                {
                    Rectangle EnemyRectangle = enemy.GetBoundaryBox();
                    if (BulletRectangle.Intersects(EnemyRectangle))
                    {
                        EnemyBulletCollide.EnemyBulletCollideResponse(enemy, bullet);
                    }
                }
                if (BulletRectangle.Intersects(MarcoRectangle))
                {
                    WarriorBulletCollide.WarriorBulletCollideResponse(marco, bullet);
                }
                if (BulletRectangle.Intersects(TarmaRectangle))
                {
                    WarriorBulletCollide.WarriorBulletCollideResponse(tarma, bullet);
                }
            }
        }
    }
}
