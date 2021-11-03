using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class CollisionDetector
    {
        private bool MarioInIntersect;
        private Color MarioColor;
        private Color EnemyColor;
        private Color ItemColor;
        private Color BlockColor;

        private Rectangle marioRectangle;
        private MarioEnemyCollide MarioEnemyCollide;
        private MarioItemCollide MarioItemCollide;
        private MarioBlockEntityCollide MarioBlockEntityCollide;
        private EnemyBlockCollide EnemyBlockCollide;
        private EnemyEnemyCollide EnemyEnemyCollide;
        private FireballEnemyCollide FireballEnemyCollide;
        private FireballBlockCollide FireballBlockCollide;
        private ItemBlockCollide ItemBlockCollide;

        public CollisionDetector(Game1 game)
        {
            MarioColor = Color.Yellow;
            EnemyColor = Color.Purple;
            ItemColor = Color.Green;
            BlockColor = Color.White;

            MarioEnemyCollide = new MarioEnemyCollide(game);
            MarioItemCollide = new MarioItemCollide(game);
            MarioBlockEntityCollide = new MarioBlockEntityCollide(game);
            EnemyBlockCollide = new EnemyBlockCollide();
            EnemyEnemyCollide = new EnemyEnemyCollide(game);
            FireballEnemyCollide = new FireballEnemyCollide(game);
            FireballBlockCollide = new FireballBlockCollide();
            ItemBlockCollide = new ItemBlockCollide();
        }

        public void DetectCollision(SpriteFactory spriteFactory, MarioEntity marioEntity, List<EnemyEntity> enemies, List<ItemEntity> items, List<BlockEntity> blockEntities, List<FireballEntity> fireballs)
        {
            marioRectangle = marioEntity.Sprite.BoundaryBox(marioEntity._position);
            MarioInIntersect = false;
            foreach (BlockEntity blockEntity in blockEntities.ToList())
            {
                Rectangle thisRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
                if (marioRectangle.Intersects(thisRectangle))
                {
                    MarioInIntersect = true;
                    MarioBlockEntityCollide.MarioCollideBlockEntityCommand(marioEntity, blockEntity, items);
                }
                else
                {
                    blockEntity.Sprite.BoxColor = BlockColor;
                }

                foreach (FireballEntity fireball in fireballs.ToList())
                {
                    Rectangle fireballRectangle = fireball.Sprite.BoundaryBox(fireball._position);
                    if (fireballRectangle.Intersects(thisRectangle))
                    {
                        FireballBlockCollide.FireballBlockCollideCommand(fireball, blockEntity);
                    }
                }
                foreach (EnemyEntity enemy in enemies.ToList())
                {
                    Rectangle enemyRectangle = enemy.Sprite.BoundaryBox(enemy._position);
                    enemy.isOnGround = false;
                    if (enemyRectangle.Intersects(thisRectangle))
                    {
                        EnemyBlockCollide.EnemyCollideBlockCommand(enemy, blockEntity);
                        enemy.isOnGround = true;
                    }
                    else
                    {
                        blockEntity.Sprite.BoxColor = BlockColor;
                    }
                }
                foreach(ItemEntity item in items.ToList())
                {
                    Rectangle enemyRectangle = item.Sprite.BoundaryBox(item._position);
                    if (enemyRectangle.Intersects(thisRectangle))
                    {
                        ItemBlockCollide.ItemCollideBlockCommand(item, blockEntity);
                    }
                    else
                    {
                        blockEntity.Sprite.BoxColor = BlockColor;
                    }
                }
            }
            foreach (EnemyEntity enemy in enemies.ToList())
            {
                
                Rectangle thisRectangle = enemy.getBoundingBox();
                if (marioRectangle.Intersects(thisRectangle))
                {
                    MarioInIntersect = true;
                    MarioEnemyCollide.MarioCollideEnemyCommand(marioEntity, enemy);
                }
                else
                {
                    enemy.Sprite.BoxColor = EnemyColor;
                }
                foreach(EnemyEntity enemy2 in enemies.ToList())
                {
                    if(!enemy2.Equals(enemy))
                    {
                        Rectangle thatRectangle = enemy2.getBoundingBox();
                        if (thisRectangle.Intersects(thatRectangle))
                            EnemyEnemyCollide.EnemyCollideEnemyCommand(enemy, enemy2);
                    }
                }
                foreach (FireballEntity fireball in fireballs.ToList())
                {
                    Rectangle fireballRectangle = fireball.Sprite.BoundaryBox(fireball._position);
                    if(thisRectangle.Intersects(fireballRectangle))
                    {
                        FireballEnemyCollide.FireballEnemyCollideCommand(enemy);
                        enemies.Remove(enemy);
                        fireballs.Remove(fireball);
                    }
                }
                
            }

            foreach (ItemEntity item in items.ToList())
            {
                Rectangle thisRectangle = item.Sprite.BoundaryBox(item._position);
                if (marioRectangle.Intersects(thisRectangle))
                {
                    MarioInIntersect = true;
                    MarioItemCollide.MarioCollideItemCommand(marioEntity, item);
                    items.Remove(item);
                }
                else
                {
                    item.Sprite.BoxColor = ItemColor;
                }
            }            
            if (!MarioInIntersect)
                marioEntity.Sprite.BoxColor = MarioColor;
        }


    }
}
