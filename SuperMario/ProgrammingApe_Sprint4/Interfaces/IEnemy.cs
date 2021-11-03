using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public interface IEnemy
    {
        Texture2D Texture { get; set; }
        String EnemyType();
        Color BoxColor { get; set; }
        Rectangle BoundaryBox(Vector2 Location);
        bool ShowBoundary { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 Location);
    }
}
