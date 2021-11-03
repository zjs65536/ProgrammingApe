using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Sprint_4
{
    public class Background
    {
        private List<IBackground> Backgrounds;
        public Background(List<IBackground> backgrounds) 
        {
            Backgrounds = backgrounds;
        }

        public void Update()
        {
            foreach (IBackground background in Backgrounds)
                background.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBackground background in Backgrounds)
                spriteBatch.Draw(background.Texture, background.Position, Color.White);
        }
    }
}
