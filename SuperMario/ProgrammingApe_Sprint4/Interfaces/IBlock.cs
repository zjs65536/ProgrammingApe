using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public interface IBlock
    {
        Texture2D Texture { get; set; }
        Color BoxColor { get; set; }
       
        String BlockType();
        Rectangle BoundaryBox(Vector2 location);
        bool ShowBoundary { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
