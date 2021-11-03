using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    class GoombaEntity : EnemyEntity
    {
        public GoombaEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            isOnGround = true;
            gravity = 0f;
            EnemyType = "goomba";

            EnemyChanging = new EnemyChanging(this);
            EnemyState = new GoomabaStandardState(this);
            Sprite = SpriteFactory.createEnemy(SpriteFactory.sprites.goomba);

            EnemyState_Enum = EnemyState_enum.GoombaAlive;

            previousEnemyState = EnemyState_Enum;
        }

        public override void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            if (EnemyType.Equals("deadGoomba") && deleteTime > 0)
                deleteTime--;
            if (deleteTime == 0)
                toBeDeleted = true;
            base.Update(gameTime, blockEntities);
        }

    }
}
