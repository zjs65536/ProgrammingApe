using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    class KoopaEntity : EnemyEntity
    {
        private float GetoutTime;
        private bool start;
        public KoopaEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            isOnGround = true;
            start = false;
            gravity = 0f;
            speedControl = 15f;
            GetoutTime = 10f;
            _position = Position;
            SpriteFactory = spriteFactory;
            EnemyType = "koopaStandard";

            EnemyChanging = new EnemyChanging(this);
            EnemyState = new KoopaStandardState(this);
            Sprite = SpriteFactory.createEnemy(SpriteFactory.sprites.greenKoopa);

            EnemyState_Enum = EnemyState_enum.KoopaAlive;

            previousEnemyState = EnemyState_Enum;
        }

        public override void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            if (EnemyType.Equals("koopaShell"))
                start = true;
            else
            {
                start = false;
                GetoutTime = 10f;
            }
            if (start && VelocityX == 0)
                GetoutTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                GetoutTime = 10f;
            if (GetoutTime <= 0f)
                EnemyState.KoopaStandardTransition();
            base.Update(gameTime, blockEntities);
        }
    }
}
