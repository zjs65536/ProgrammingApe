using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public enum HealthBarSituation { Green, Yellow, Red }
    public class GameHUD
    {
        private Game1 Game;
        private Camera Camera;
        private RectangleOutline RectangleOutline;
        private SpriteFont SpriteFont;
        private SpriteFont NameSpriteFont;
        private HealthBarSituation MarcoHealthBarSituation;
        private HealthBarSituation TarmaHealthBarSituation;
        private HealthBarSituation PreviousMarcoHealthBarSituation;
        private HealthBarSituation PreviousTarmaHealthBarSituation;
        private WarriorEntity Marco;
        private WarriorEntity Tarma;
        private Texture2D MarcoHealthBarSprite;
        private Texture2D TarmaHealthBarSprite;
        private Texture2D GreenHealthBar;
        private Texture2D YellowHealthBar;
        private Texture2D RedHealthBar;

        private String MarcoAmmo;
        private String TarmaAmmo;
        private String MarcoCurrentWeapon;
        private String TarmaCurrentWeapon;
        private String MarcoHealth;
        private String TarmaHealth;
        private String MPoint;
        private String TPoint;
        public int MarcoPoint;
        public int TarmaPoint;

        public Rectangle MarcoHealthBarRectangle;
        public Rectangle TarmaHealthBarRectangle;

        private WarriorWeaponState MarcoWeapon;
        private WarriorWeaponState TarmaWeapon;
        public GameHUD(Game1 game, Camera camera, WarriorEntity marco, WarriorEntity tarma)
        {
            Game = game;
            Camera = camera;
            RectangleOutline = new RectangleOutline();
            GreenHealthBar = Game.Content.Load<Texture2D>("HealthBar/GreenHealthBar");
            YellowHealthBar = Game.Content.Load<Texture2D>("HealthBar/YellowHealthBar");
            RedHealthBar = Game.Content.Load<Texture2D>("HealthBar/RedHealthBar");
            Marco = marco;
            Tarma = tarma;

            MarcoPoint = 0;
            TarmaPoint = 0;
            MarcoHealthBarSprite = GreenHealthBar;
            TarmaHealthBarSprite = GreenHealthBar;
            MarcoHealthBarRectangle = new Rectangle(100, 40, 150, 20);
            TarmaHealthBarRectangle = new Rectangle(550, 40, 150, 20);
            MarcoHealthBarSituation = HealthBarSituation.Green;
            PreviousMarcoHealthBarSituation = HealthBarSituation.Green;
            TarmaHealthBarSituation = HealthBarSituation.Green;
            PreviousTarmaHealthBarSituation = HealthBarSituation.Green;

            SpriteFont = Game.Content.Load<SpriteFont>("SpriteFont/HUD");
            NameSpriteFont = Game.Content.Load<SpriteFont>("SpriteFont/Name");
        }

        public void Update(GameTime gameTime)
        {
            MarcoWeapon = Marco.WarriorWeaponState;
            TarmaWeapon = Tarma.WarriorWeaponState;
            MarcoHealthBarRectangle = new Rectangle(((int)Camera.Position.X + 100), ((int)Camera.Position.Y + 50), 150, 20);
            TarmaHealthBarRectangle = new Rectangle(((int)Camera.Position.X + 550), ((int)Camera.Position.Y + 50), 150, 20);

            if (MarcoWeapon == WarriorWeaponState.Pistal)
                MarcoCurrentWeapon = "WEAPON: Pistol";
            else if (MarcoWeapon == WarriorWeaponState.machineGun)
                MarcoCurrentWeapon = "WEAPON: Machine Gun";
            else
                MarcoCurrentWeapon = "WEAPON: Laser Gun";
            if (TarmaWeapon == WarriorWeaponState.Pistal)
                TarmaCurrentWeapon = "WEAPON: Pistol";
            else if (TarmaWeapon == WarriorWeaponState.machineGun)
                TarmaCurrentWeapon = "WEAPON: Machine Gun";
            else
                TarmaCurrentWeapon = "WEAPON: Laser Gun";

            if (Marco.WeaponAmmo > 0)
                MarcoAmmo = Marco.WeaponAmmo.ToString();
            else
                MarcoAmmo = " --- ";

            if (Tarma.WeaponAmmo > 0)
                TarmaAmmo = Tarma.WeaponAmmo.ToString();
            else
                TarmaAmmo = " --- ";

            MarcoHealth = "HEALTH: " + Marco.HealthPoint.ToString();
            TarmaHealth = "HEALTH: " + Tarma.HealthPoint.ToString();

            MPoint = "SCORE: " + MarcoPoint.ToString();
            TPoint = "SCORE: " + TarmaPoint.ToString();

            HealthBarUpdate();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(NameSpriteFont, "MARCO", new Vector2(Camera.Position.X + 10, Camera.Position.Y + 8), Color.White);
            spriteBatch.DrawString(SpriteFont, "AMMO:", new Vector2(Camera.Position.X + 100, Camera.Position.Y + 10), Color.White);
            spriteBatch.DrawString(SpriteFont, MarcoAmmo, new Vector2(Camera.Position.X + 160, Camera.Position.Y + 10), Color.White);
            spriteBatch.DrawString(SpriteFont, MarcoCurrentWeapon, new Vector2(Camera.Position.X + 100, Camera.Position.Y + 30), Color.White);
            spriteBatch.DrawString(SpriteFont, MarcoHealth, new Vector2(Camera.Position.X + 10, Camera.Position.Y + 55), Color.White);
            spriteBatch.DrawString(SpriteFont, "LIVES:" + Marco.WarriorLife.ToString(), new Vector2(Camera.Position.X + 10, Camera.Position.Y + 35), Color.White);
            //spriteBatch.DrawString(SpriteFont, MPoint, new Vector2(Camera.Position.X + 210, Camera.Position.Y + 10), Color.White);

            spriteBatch.DrawString(NameSpriteFont, "TARMA", new Vector2(Camera.Position.X + 460, Camera.Position.Y + 8), Color.White);
            spriteBatch.DrawString(SpriteFont, "AMMO:", new Vector2(Camera.Position.X + 550, Camera.Position.Y + 10), Color.White);
            spriteBatch.DrawString(SpriteFont, TarmaAmmo, new Vector2(Camera.Position.X + 610, Camera.Position.Y + 10), Color.White);
            spriteBatch.DrawString(SpriteFont, TarmaCurrentWeapon, new Vector2(Camera.Position.X + 550, Camera.Position.Y + 30), Color.White);
            spriteBatch.DrawString(SpriteFont, TarmaHealth, new Vector2(Camera.Position.X + 460, Camera.Position.Y + 55), Color.White);
            spriteBatch.DrawString(SpriteFont, "LIVES:" + Tarma.WarriorLife.ToString(), new Vector2(Camera.Position.X + 460, Camera.Position.Y + 35), Color.White);
            //spriteBatch.DrawString(SpriteFont, MPoint, new Vector2(Camera.Position.X + 660, Camera.Position.Y + 10), Color.White);

            spriteBatch.Draw(MarcoHealthBarSprite, new Rectangle((int)(Camera.Position.X + 100), (int)(Camera.Position.Y + 50), Marco.HealthPoint * 3 / 2, MarcoHealthBarRectangle.Height), Color.White);
            spriteBatch.Draw(TarmaHealthBarSprite, new Rectangle((int)(Camera.Position.X + 550), (int)(Camera.Position.Y + 50), Tarma.HealthPoint * 3 / 2, TarmaHealthBarRectangle.Height), Color.White);

            RectangleOutline.DrawRectangle(spriteBatch, MarcoHealthBarRectangle, Color.White, 1);
            RectangleOutline.DrawRectangle(spriteBatch, TarmaHealthBarRectangle, Color.White, 1);
        }

        public void HealthBarUpdate()
        {
            if (Marco.HealthPoint >= 60)
                MarcoHealthBarSituation = HealthBarSituation.Green;
            if (Marco.HealthPoint >= 25 && Marco.HealthPoint < 60)
                MarcoHealthBarSituation = HealthBarSituation.Yellow;
            if (Marco.HealthPoint < 25)
                MarcoHealthBarSituation = HealthBarSituation.Red;
            if (Tarma.HealthPoint >= 60)
                TarmaHealthBarSituation = HealthBarSituation.Green;
            if (Tarma.HealthPoint >= 25 && Tarma.HealthPoint < 60)
                TarmaHealthBarSituation = HealthBarSituation.Yellow;
            if (Tarma.HealthPoint < 25)
                TarmaHealthBarSituation = HealthBarSituation.Red;

            if (MarcoHealthBarSituation == HealthBarSituation.Yellow && PreviousMarcoHealthBarSituation == HealthBarSituation.Green)
            {
                MarcoHealthBarSprite = YellowHealthBar;
            }
            if(MarcoHealthBarSituation == HealthBarSituation.Red && PreviousMarcoHealthBarSituation == HealthBarSituation.Yellow)
            {
                MarcoHealthBarSprite = RedHealthBar;
            }
            if (MarcoHealthBarSituation == HealthBarSituation.Green && PreviousMarcoHealthBarSituation == HealthBarSituation.Red)
            {
                MarcoHealthBarSprite = GreenHealthBar;
            }
            PreviousMarcoHealthBarSituation = MarcoHealthBarSituation;
            if (TarmaHealthBarSituation == HealthBarSituation.Yellow && PreviousTarmaHealthBarSituation == HealthBarSituation.Green)
            {
                TarmaHealthBarSprite = YellowHealthBar;
            }
            if (TarmaHealthBarSituation == HealthBarSituation.Red && PreviousTarmaHealthBarSituation == HealthBarSituation.Yellow)
            {
                TarmaHealthBarSprite = RedHealthBar;
            }
            if (TarmaHealthBarSituation == HealthBarSituation.Green && PreviousTarmaHealthBarSituation == HealthBarSituation.Red)
            {
                TarmaHealthBarSprite = GreenHealthBar;
            }
            PreviousTarmaHealthBarSituation = TarmaHealthBarSituation;
        }
    }
}
