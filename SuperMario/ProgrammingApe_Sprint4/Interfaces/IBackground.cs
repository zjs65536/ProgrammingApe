using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    public interface IBackground
    {
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
