using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Controller_Command;

namespace Sprint_4
{
    class MarioItemCollide
    {
        private Game1 Game { get; set; }
        public MarioItemCollide(Game1 game)
        {
            Game = game;
        }

        public void MarioCollideItemCommand(MarioEntity marioEntity, ItemEntity item)
        {
            marioEntity.Sprite.BoxColor = Color.Red;
            item.Sprite.BoxColor = Color.Red;
            if (!item.Sprite.isUsed)
            {
                if (item.ItemType.Equals("Coin") && marioEntity.MarioActionState_Enum != MarioActionState_enum.Dead)
                {
                    Game.gameHUD.Coins++;
                    Game.gameHUD.Points += 200;
                    marioEntity.SoundManager.PlayCollectCoin();
                }
                if (item.ItemType.Equals("Flower"))
                {
                    Game.gameHUD.Points += 1000;
                    marioEntity.SoundManager.PlayGainPowerUp();
                    if (marioEntity.MarioStatus_Enum.Equals(MarioStatus_enum.Standard))
                    {
                        marioEntity.MarioStatus_Enum = MarioStatus_enum.Super;
                        marioEntity._position.Y -= 8;
                    }
                    else if (marioEntity.MarioStatus_Enum.Equals(MarioStatus_enum.Super))
                        marioEntity.MarioStatus_Enum = MarioStatus_enum.Fire;
                }
                if (item.ItemType.Equals("PUMushroom"))
                {
                    Game.gameHUD.Points += 1000;
                    marioEntity.SoundManager.PlayGainPowerUp();
                    if (marioEntity.MarioStatus_Enum.Equals(MarioStatus_enum.Standard))
                    {
                        marioEntity.MarioStatus_Enum = MarioStatus_enum.Super;
                        marioEntity._position.Y -= 8;
                    }
                }
                if (item.ItemType.Equals("OUMushroom"))
                {
                    marioEntity.marioLife++;
                    marioEntity.SoundManager.PlayGainExtraLife();
                }
                if (item.ItemType.Equals("Star"))
                {
                    Game.gameHUD.Points += 1000;
                }
                item.Sprite.isUsed = true;
            }
        }
    }
}
