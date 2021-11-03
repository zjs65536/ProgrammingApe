using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
	public class SpriteFactory : ISpriteFactory
	{
		public Game1 Game { get; set; }
		private Texture2D currentSprite;
		private GraphicsDevice GraphicsDevice;

		public SpriteFactory(Game1 game, GraphicsDevice graphicsDevice)
		{
			Game = game;
			GraphicsDevice = graphicsDevice;
		}

		public enum sprites
		{
			// Small Mario
			marioIdleLeft, marioIdleRight, marioRunLeft, marioRunRight, marioJumpLeft, marioJumpRight, marioDead, flagSmallMario,
			// Big Mario
			bigMarioIdleLeft, bigMarioIdleRight, bigMarioRunLeft, bigMarioRunRight, bigMarioJumpLeft, bigMarioJumpRight, bigMarioCrouchLeft, bigMarioCrouchRight, flagBigMario,
			// Fire Mario
			fireMarioIdleLeft, fireMarioIdleRight, fireMarioRunLeft, fireMarioRunRight, fireMarioJumpLeft, fireMarioJumpRight, fireMarioCrouchLeft, fireMarioCrouchRight, flagFireMario,
			// Items
			coin, flower, star, greenMushroom, redMushroom, fireball,
			// Enemies
			goomba, redKoopa, greenKoopa, deadGoomba, koopaShell, piranha,
			// Blocks
			floorBlock, usedQuestionBlock, stairBlock, fourPiecesBlock, pipe, leftPipe, longPipe, questionBlock, hiddenBlock, brickBlock, flagpole, underBrickBlock, underFloorBlock,
			// Background Textures
			cloud1, cloud2, cloud3, grass1, grass2, grass3, mountain1, mountain2, castle, blackRectangle,
			// HUD Avatars
			marioHUD, coinHUD,
        }

		public IMario createSprite(SpriteFactory.sprites sprite)
		{
			// Small Mario
			if (sprite.Equals(sprites.marioIdleLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioIdleLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.marioIdleRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioIdleRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.marioJumpLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioJumpLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.marioJumpRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioJumpRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.marioDead))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioDead");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.marioRunLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioRunLeft");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.marioRunRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/marioRunRight");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.flagSmallMario))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/flagSmallMario");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}

			// Big Mario
			if (sprite.Equals(sprites.bigMarioCrouchLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioCrouchLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioCrouchRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioCrouchRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioJumpLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioJumpLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioJumpRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioJumpRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioRunLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioRunLeft");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioRunRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioRunRight");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioIdleLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioIdleLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.bigMarioIdleRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/bigMarioIdleRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.flagBigMario))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/flagBigMario");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}

			// Fire Mario
			if (sprite.Equals(sprites.fireMarioCrouchLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioCrouchLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioCrouchRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioCrouchRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioJumpLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioJumpLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioJumpRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioJumpRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioRunLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioRunLeft");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioRunRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioRunRight");
				return new MarioAnimatedSprite(GraphicsDevice, currentSprite, 1, 3, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioIdleLeft))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioIdleLeft");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.fireMarioIdleRight))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/fireMarioIdleRight");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.flagFireMario))
			{
				currentSprite = Game.Content.Load<Texture2D>("Mario/flagFireMario");
				return new MarioUnanimatedSprite(GraphicsDevice, currentSprite, Game.showBox);
			}
			return null;
		}

		public IItem createItem(SpriteFactory.sprites sprite, Vector2 location)
		{
			// Items
			if (sprite.Equals(sprites.coin))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/coin");
				return new coinRotate(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.flower))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/flower");
				return new flowerFlash(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.star))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/star");
				return new starFlash(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.greenMushroom))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/greenMushroom");
				return new greenMushroom(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.redMushroom))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/redMushroom");
				return new redMushroom(GraphicsDevice, currentSprite, Game.showBox);
			}
			return null;
		}

		public IEnemy createEnemy(SpriteFactory.sprites sprite)
		{
			// Enemies
			if (sprite.Equals(sprites.goomba))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/goomba");
				return new goombaWalk(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.redKoopa))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/redKoopa");
				return new koopaWalk(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.greenKoopa))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/greenKoopa");
				return new koopaWalk(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.deadGoomba))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/deadGoomba");
				return new deadGoomba(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.koopaShell))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/koopaShell");
				return new koopaShell(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.piranha))
			{
				currentSprite = Game.Content.Load<Texture2D>("Enemies/piranhaPlant");
				return new piranha(GraphicsDevice, currentSprite, Game.showBox);
			}
			return null;
		}

		public IBlock createBlock(SpriteFactory.sprites sprite)
		{
			// Blocks
			if(sprite.Equals(sprites.hiddenBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/hiddenBlock");
				return new hiddenBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if(sprite.Equals(sprites.brickBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/brickBlock");
				return new brickBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if(sprite.Equals(sprites.floorBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/floorBlock");
				return new floorBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if(sprite.Equals(sprites.questionBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/questionBlock");
				return new questionBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if(sprite.Equals(sprites.stairBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/stairBlock");
				return new stairBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if(sprite.Equals(sprites.usedQuestionBlock))
            {
				currentSprite = Game.Content.Load<Texture2D>("Blocks/usedQuestionBlock");
				return new usedQuestionBlock(GraphicsDevice, currentSprite, Game.showBox);
            }
			if (sprite.Equals(sprites.fourPiecesBlock))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/fourPiecesBlock");
				return new fourPiecesBlock(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.pipe))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/pipe");
				return new pipe(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.leftPipe))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/leftPipe");
				return new pipe(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.longPipe))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/longPipe");
				return new pipe(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.flagpole))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/flagpole");
				return new flagpole(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.underBrickBlock))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/underBreakBlock");
				return new underBrickBlock(GraphicsDevice, currentSprite, Game.showBox);
			}
			if (sprite.Equals(sprites.underFloorBlock))
			{
				currentSprite = Game.Content.Load<Texture2D>("Blocks/underFloorBlock");
				return new underFloorBlock(GraphicsDevice, currentSprite, Game.showBox);
			}
			return null;
		}

		public IBackground createBackground(SpriteFactory.sprites sprite, Vector2 Position)
        {
			if(sprite.Equals(sprites.cloud1))
            {
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/Cloud1");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.cloud2))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/cloud2");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.cloud3))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/cloud3");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.grass1))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/grass1");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.grass2))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/grass2");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.grass3))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/grass3");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.mountain1))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/mountain1");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.mountain2))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/mountain2");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.castle))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/castle");
				return new BackgroundSprite(currentSprite, Position);
			}
			if (sprite.Equals(sprites.blackRectangle))
			{
				currentSprite = Game.Content.Load<Texture2D>("Backgrounds/blackrectangle");
				return new BackgroundSprite(currentSprite, Position);
			}
			return null;
        }

		public IFireball createFireball(SpriteFactory.sprites sprite)
		{
			if (sprite.Equals(sprites.fireball))
			{
				currentSprite = Game.Content.Load<Texture2D>("Items/fireball");
				return new fireBall(GraphicsDevice, currentSprite, Game.showBox);
			}
			return null;
		}
		public ISprite createAvatar(SpriteFactory.sprites sprite)
        {
			if(sprite.Equals(sprites.marioHUD))
			{
				currentSprite = Game.Content.Load<Texture2D>("HUDSprite/marioHUD");
				return new HUDAvatar(currentSprite); 
			}
			if (sprite.Equals(sprites.coinHUD))
			{
				currentSprite = Game.Content.Load<Texture2D>("HUDSprite/coinHUD");
				return new HUDAvatar(currentSprite);
			}
			return null;
        }
	}
}