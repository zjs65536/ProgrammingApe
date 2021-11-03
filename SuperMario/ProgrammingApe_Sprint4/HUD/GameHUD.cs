using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    public class GameHUD
    {
        public Game1 Game;
        private MarioEntity MarioEntity;
        private SpriteFactory SpriteFactory;
        private SpriteFont SpriteFont;
        private Camera Camera;
        private ISprite MarioHUD;
        private ISprite CoinHUD;

        private float CurrentTime;
        private float OneSecond;
        public int Points, Lives, Coins, Times;
        private String Point, Life, Coin, Time;

        private bool DecreaseTime;
        private bool playedWarn;

        public GameHUD(Game1 game, Camera camera, MarioEntity marioEntity, SpriteFactory spriteFactory)
        {
            Game = game;
            Camera = camera;
            MarioEntity = marioEntity;
            SpriteFactory = spriteFactory;

            Points = 1000000;
            Coins = 100;
            Times = 1400;

            DecreaseTime = true;
            playedWarn = false;
            CurrentTime = 0f;
            OneSecond = 1f;
            SpriteFont = Game.Content.Load<SpriteFont>("Fonts/HUD");
            MarioHUD = SpriteFactory.createAvatar(SpriteFactory.sprites.marioHUD);
            CoinHUD = SpriteFactory.createAvatar(SpriteFactory.sprites.coinHUD);
        }

    public void Update(GameTime gameTime)
        {
            Lives = MarioEntity.marioLife;
            CurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if ((CurrentTime >= OneSecond) && DecreaseTime)
            {
                Times--;
                CurrentTime -= 1f;
            }
            if (Coins / 100 == 2)
            {
                Coins -= 100;
                MarioEntity.marioLife++;
            }

            Point = "MARIO\n" + Points.ToString().Substring(1);
            Life = "\n    X " + Lives.ToString();
            Coin = "\n   X " + Coins.ToString().Substring(1);
            Time = "TIME\n" + Times.ToString().Substring(1);

            if(Times == 1050 && !playedWarn)
            {
                MarioEntity.SoundManager.PlayTimeWarning();
                playedWarn = true;
            }
            if (Times == 1000)
            {
                Game.marioEntity.MarioState.DieTransition();
                Game.marioEntity.levelReset = true;
                DecreaseTime = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MarioHUD.Draw(spriteBatch, new Vector2(Camera.Position.X + 200, Camera.Position.Y + 45));
            CoinHUD.Draw(spriteBatch, new Vector2(Camera.Position.X + 400, Camera.Position.Y + 40));
            spriteBatch.DrawString(SpriteFont, Point, new Vector2(Camera.Position.X + 20, Camera.Position.Y + 20), Color.White);
            spriteBatch.DrawString(SpriteFont, Life, new Vector2(Camera.Position.X + 200, Camera.Position.Y + 20), Color.White);
            spriteBatch.DrawString(SpriteFont, Coin, new Vector2(Camera.Position.X + 400, Camera.Position.Y + 20), Color.White);
            spriteBatch.DrawString(SpriteFont, Time, new Vector2(Camera.Position.X + 600, Camera.Position.Y + 20), Color.White);
        }
    }
}


