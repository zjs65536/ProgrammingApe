using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Controller_Command;

namespace Sprint_3
{
    class MarioBlockCollide
    {
        private Game1 Game { get; set; }
        public MarioBlockCollide(Game1 game)
        {
            Game = game;
        }

        public void MarioCollideBlockCommand(MarioEntity marioEntity, IBlock block)
        {
            marioEntity.Sprite.BoxColor = Color.Red;
            block.BoxColor = Color.Red;
            Rectangle marioRectangle = marioEntity.Sprite.BoundaryBox(marioEntity._position);
            Rectangle blockRectangle = block.BoundaryBox();
            Rectangle Intersect = Rectangle.Intersect(marioRectangle, blockRectangle);
            if (Intersect.Width > Intersect.Height)
            {
                if (marioRectangle.Center.Y > blockRectangle.Center.Y)
                {
                    marioEntity._position.Y += Intersect.Height;
                    marioEntity.MarioState.IdleTransition();
                    marioEntity.VelocityY = 2f;
                }

                if (marioRectangle.Center.Y < blockRectangle.Center.Y)
                {
                    marioEntity._position.Y -= Intersect.Height;
                    marioEntity.MarioState.IdleTransition(); //管理落地
                }
            }
            else if (Intersect.Height > Intersect.Width)
            {
                if (marioRectangle.Center.X > blockRectangle.Center.X)
                {
                    marioEntity._position.X += Intersect.Width;
                }
                if (marioRectangle.Center.X < blockRectangle.Center.X)
                {
                    marioEntity._position.X -= Intersect.Width;
                }
                marioEntity.MarioState.FallingTransition();
            }
        }
    }
}
