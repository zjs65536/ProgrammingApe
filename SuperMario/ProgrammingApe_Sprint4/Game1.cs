using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Controller_Command;
using System.Collections.Generic;
using Sprint_4.TileMap;
using System;
using System.Linq;

namespace Sprint_4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameControll gameControll;
        public MarioCommands _action;
        public GameState gameExperienceAction;
        public KeyboardController keyboard;
        public GamepadController gamepad;
        private SpriteFactory spriteFactory;
        private CollisionDetector CollisionDetector;

        public MarioEntity marioEntity;
        public List<EnemyEntity> enemies;
        public List<ItemEntity> items;
        public List<BlockEntity> blockEntities;
        public List<IBackground> backgrounds;
        public List<FireballEntity> fireballs;

        public bool showBox = false;
        public bool FlagCounted = false;
        public bool gameOver;
        public bool inHiddenRoom;
        public Vector2 cameraPosition;

        private SpriteManager spriteManager;
        public SoundManager soundManager;
        private LevelBuilder levelBuilder;
        public Camera camera;
        public GameHUD gameHUD;
        public GameState_Enum gameState_Enum;
        public Background Background;
        Vector2 parallax = new Vector2(1f);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            gameState_Enum = GameState_Enum.Playing;
            gameControll = new GameControll(this);
            soundManager = new SoundManager(this);
            marioEntity = new MarioEntity(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            camera = new Camera(GraphicsDevice.Viewport);
            gameControll.Load(camera);

            //Sound
            soundManager.LoadSounds();
            soundManager.PlayBackgroundSong();

            //Graph
            spriteFactory = new SpriteFactory(this, graphics.GraphicsDevice);
            enemies = new List<EnemyEntity>();
            items = new List<ItemEntity>();
            blockEntities = new List<BlockEntity>();
            fireballs = new List<FireballEntity>();
            backgrounds = new List<IBackground>();
            marioEntity.Load(spriteFactory, camera,soundManager);
            gameHUD = new GameHUD(this, camera, marioEntity, spriteFactory);

            keyboard = new KeyboardController(this, marioEntity);
            gamepad = new GamepadController(this, marioEntity);

            //Action
            gameExperienceAction = new GameState(this);
            CollisionDetector = new CollisionDetector(this);
            _action = new MarioCommands(this, marioEntity, fireballs);
            spriteManager = new SpriteManager(spriteFactory, enemies, items, blockEntities, backgrounds);
            levelBuilder = new LevelBuilder(spriteManager, "MarioMap1.xml");

            // Other
            _action.CommandUpdate(keyboard, gamepad);
            gameExperienceAction.CommandUpdate(keyboard, gamepad);
            inHiddenRoom = false;
            gameOver = false;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            levelBuilder.Load();
           
            Background = new Background(backgrounds);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyboard.UpdateInput();
            gamepad.UpdateInput();
            if (gameState_Enum == GameState_Enum.Playing )
            {
                
                CollisionDetector.DetectCollision(spriteFactory, marioEntity, enemies, items, blockEntities, fireballs);

                if (!inHiddenRoom)
                {
                    Rectangle mainworld = new Rectangle(0, 0, 4000, 400);
                    camera.Limits = mainworld;
                    cameraPosition = new Vector2(marioEntity._position.X, GraphicsDevice.Viewport.Height / 2);
                    marioEntity.YMax = GraphicsDevice.Viewport.Height;
                }
                else
                {
                    Rectangle underworld = new Rectangle(0, 480, 800, 480);
                    camera.Limits = underworld;
                    cameraPosition = new Vector2(marioEntity._position.X + 240, (GraphicsDevice.Viewport.Height*3) / 2);
                    marioEntity.YMax = GraphicsDevice.Viewport.Height * 2;
                }

                marioEntity.Update(gameTime, blockEntities);

                camera.LookAt(cameraPosition);


                foreach (EnemyEntity enemy in enemies.ToList())
                {
                    if (enemy._position.X < cameraPosition.X + 400 || enemy._position.X < 800)
                    {
                        enemy.startMoving = true;
                    }
                    if (enemy.startMoving)
                    {
                        enemy.Sprite.ShowBoundary = showBox;
                        enemy.Update(gameTime, blockEntities);
                    }
                    if (enemy.toBeDeleted)
                        enemies.Remove(enemy);
                }
                foreach (ItemEntity item in items.ToList())
                {
                    item.Sprite.ShowBoundary = showBox;
                    item.Update(gameTime, blockEntities);
                }
                foreach (BlockEntity blockEntity in blockEntities.ToList())
                {
                    blockEntity.Sprite.ShowBoundary = showBox;
                    blockEntity.Update(gameTime);
                }
                if (fireballs.Count != 0)
                {
                    foreach (FireballEntity fireball in fireballs.ToList())
                    {
                        fireball.Sprite.ShowBoundary = showBox;
                        fireball.Update(gameTime, blockEntities);
                        if (fireball.Destroyed())
                            fireballs.Remove(fireball);
                    }
                }
                gameHUD.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if(!inHiddenRoom)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(new Vector2(0.5f, 0)));
                Background.Draw(spriteBatch);
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(parallax));
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(parallax));
                Background.Draw(spriteBatch);
            }

            if (gameState_Enum != GameState_Enum.Lose)
            {
                foreach (EnemyEntity enemy in enemies.ToList())
                {
                    if (enemy._position.Y > 500)
                        enemies.Remove(enemy);
                    enemy.Sprite.ShowBoundary = showBox;
                    enemy.Draw(spriteBatch);
                }
                foreach (BlockEntity blockEntity in blockEntities)
                {
                    blockEntity.Sprite.ShowBoundary = showBox;
                    blockEntity.Draw(spriteBatch);
                }
                foreach (ItemEntity item in items.ToList())
                {
                    if (item != null)
                    {
                        if (item._position.Y > 500 && !item.ItemType.Equals("Coin"))
                            items.Remove(item);
                        item.Sprite.ShowBoundary = showBox;
                        item.Draw(spriteBatch);
                    }
                }
                if (fireballs.Count != 4)
                {
                    foreach (FireballEntity fireball in fireballs.ToList())
                    {
                        fireball.Sprite.ShowBoundary = showBox;
                        fireball.Draw(spriteBatch);
                    }
                }
                marioEntity.Draw(spriteBatch);
            }
            if (gameState_Enum == GameState_Enum.Lose && !gameOver)
            {
                soundManager.PlayGameOver();
                gameOver = true;
            }
            gameHUD.Draw(spriteBatch);
            gameControll.Draw(spriteBatch); 

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            LoadContent();
        }
    }
}
