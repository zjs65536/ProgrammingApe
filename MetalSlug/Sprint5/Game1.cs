using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFactory SpriteFactory;
        public CollisionDetector CollisionDetector;
        public KeyboardController KeyboardController;
        public EnemyReaction EnemyReaction;
        public SoundManager SoundManager;
        public MapManager MapManager;
        public Camera Camera;
        public GameHUD GameHUD;
        public Background Background;
        public GameControll GameControll;

        // Warrior
        public MarcoEntity Marco;
        public TarmaEntity Tarma;
        // Enemies
        public List<EnemyEntity> Enemies;
        // Blocks
        public List<BlockEntity> Blocks;
        // Weapons
        public List<WeaponEntity> Weapons;
        // Bullets
        public List<BulletEntity> Bullets;
        // Backgrounds
        public List<ISprite> Backgrounds;

        public Vector2 CameraPosition;
        public GameState GameState;
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
            SpriteFactory = new SpriteFactory(this, GraphicsDevice);
            SoundManager = new SoundManager(this);
            Camera = new Camera(GraphicsDevice.Viewport);
            GameState = GameState.Playing;
            Background = new Background(this);
            // Entities
            Enemies = new List<EnemyEntity>();
            Weapons = new List<WeaponEntity>();
            Bullets = new List<BulletEntity>();
            Blocks = new List<BlockEntity>();
            Backgrounds = new List<ISprite>();
            MapManager = new MapManager(this, "Map.xml", Enemies, Blocks);
            //Warrior
            Marco = new MarcoEntity(this);
            Tarma = new TarmaEntity(this);
            GameHUD = new GameHUD(this, Camera, Marco, Tarma);
            GameControll = new GameControll(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Sound
            SoundManager.LoadSounds();
            SoundManager.PlayBackgroundSong();
            // Warriors
            Marco.Load();
            Tarma.Load();
            // Keyboard
            KeyboardController = new KeyboardController(this, Marco, Tarma, Bullets);
            // Action
            CollisionDetector = new CollisionDetector(this);
            EnemyReaction = new EnemyReaction(this);
            // Map
            MapManager.Load();
            GameControll.Load(Camera);
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
            KeyboardController.UpdateInpute();
            if (GameState != GameState.Lose)
            {
                CollisionDetector.CollisionDetect(Marco, Tarma, Blocks, Enemies, Weapons, Bullets);
                EnemyReaction.EnemySmartReaction(Marco, Tarma, Enemies);
                if(GameState == GameState.Win)
                {
                    Marco.WarriorState = WarriorState.Celebrate;
                    Tarma.WarriorState = WarriorState.Celebrate;
                }

                Marco.Update(gameTime, Blocks);
                Tarma.Update(gameTime, Blocks);
                Camera.Limits = new Rectangle(0, 0, 4016, 500);
                if (Marco.WarriorLife > 0 && Tarma.WarriorLife > 0)
                {
                    CameraPosition = new Vector2((Marco.Position.X + Tarma.Position.X) / 2, GraphicsDevice.Viewport.Height / 2);
                }
                else if(Marco.WarriorLife > 0)
                {
                    CameraPosition = new Vector2(Marco.Position.X, GraphicsDevice.Viewport.Height / 2);
                }
                else
                {
                    CameraPosition = new Vector2(Tarma.Position.X, GraphicsDevice.Viewport.Height / 2);
                }
                Camera.LookAt(CameraPosition);
                if (Camera.Position.X > 2600)
                    SoundManager.PlayBackgroundSong2();
                // Enemies Update
                foreach (EnemyEntity enemy in Enemies.ToList())
                {
                    enemy.Update(gameTime);
                    if (enemy.isDead && enemy.ClearTime == 0)
                    {
                        if(enemy.EnemyType == EnemyType.Bunker)
                        {
                            WeaponEntity weapon = new LaserGunEntity(this, enemy.Position + new Vector2(20, 25));
                            Weapons.Add(weapon);
                        }
                        Enemies.Remove(enemy);
                    }    
                }

                // Weapons Update
                foreach (WeaponEntity weapon in Weapons.ToList())
                {
                    weapon.Update(gameTime);
                    if (weapon.isDestroyed)
                        Weapons.Remove(weapon);
                }

                // Blocks Update
                foreach (BlockEntity block in Blocks.ToList())
                {
                    block.Update(gameTime);
                    if (block.isDestroyed)
                    {
                        if(block.BlockEnum == BlockEnum.WoodenBox)
                        {
                            WeaponEntity weapon = new MachineGunEntity(this, block.Position);
                            Weapons.Add(weapon);
                        }
                        Blocks.Remove(block);
                    }
                }

                // Bullets Update
                foreach (BulletEntity bullet in Bullets.ToList())
                {
                    bullet.Update(gameTime);
                    if (bullet.isDestroyed)
                        Bullets.Remove(bullet);
                }
                GameHUD.Update(gameTime);
            }
            GameControll.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetViewMatrix(new Vector2(1f, 1f)));
            Background.Draw(spriteBatch);
            if (GameState != GameState.Lose)
            {
                // Draw Blocks
                foreach (BlockEntity block in Blocks)
                {
                    block.Draw(spriteBatch);
                }

                // Draw Weapons
                foreach (WeaponEntity weapon in Weapons)
                {
                    weapon.Draw(spriteBatch);
                }

                // Draw Enemies
                foreach (EnemyEntity enemy in Enemies)
                {
                    enemy.Draw(spriteBatch);
                }

                // Draw Warriors
                Marco.Draw(spriteBatch);
                Tarma.Draw(spriteBatch);

                // Draw Bullets
                foreach (BulletEntity bullet in Bullets)
                {
                    bullet.Draw(spriteBatch);
                }
            }

            GameHUD.Draw(spriteBatch);
            GameControll.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void Reset()
        {
            this.Initialize();
            this.LoadContent();
        }
    }
}
