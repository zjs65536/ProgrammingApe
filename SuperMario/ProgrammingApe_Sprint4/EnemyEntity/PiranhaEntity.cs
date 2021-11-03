using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    class PiranhaEntity : EnemyEntity
    {

        public PiranhaEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            isOnGround = true;
            gravity = 0f;
            speedControl = 15f;
            _position = Position;
            Anchor = Position;
            SpriteFactory = spriteFactory;
            EnemyType = "piranha";

            VelocityY = -1;
            //   EnemyChanging = new EnemyChanging(this);
            EnemyState = new PiranhaStandardState(this);
            Sprite = SpriteFactory.createEnemy(SpriteFactory.sprites.piranha);

            EnemyState_Enum = EnemyState_enum.Piranha;

            previousEnemyState = EnemyState_Enum;
        }

        public override void ChangeDirection()
        {
            // VelocityX *= -1;
        }


        public override Rectangle getBoundingBox()
        {
            return Sprite.BoundaryBox(_position);
        }

        public override void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            Sprite.Update(gameTime);
            //BoundaryCheck();

            //  if (Math.Abs(_position.Y - Anchor.Y) > 30|| Math.Abs(_position.Y - Anchor.Y) <= 0)
            //       VelocityY = VelocityY * -1;


            showBox = SpriteFactory.Game.showBox;
            Sprite.ShowBoundary = showBox;

            EnemyState?.Update(gameTime);
            //  VelocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds; 
            //  _position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds * speedControl;
            _position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds * gravityControl;


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

    }
}
