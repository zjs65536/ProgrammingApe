using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WoodenBoxEntity : BlockEntity
    {
        private Game1 Game;

        public WoodenBoxEntity(Game1 game, Vector2 position) : base(game, position)
        {
            Game = game;
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.WoodenBox);
            BlockEnum = BlockEnum.WoodenBox;

            BreakPoint = 50;
        }
    }
}
