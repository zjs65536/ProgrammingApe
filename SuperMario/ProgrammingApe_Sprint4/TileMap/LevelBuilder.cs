using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Sprint_4.TileMap
{
    public class LevelBuilder
    {
        public SpriteManager spriteManager;
        string fileName;
        public LevelBuilder(SpriteManager SpriteManager, string FileName)
        {
            spriteManager = SpriteManager;
            fileName = FileName;
        }

        public void Load()
        {
            BlockLoad();
            EnemyLoad();
            ItemLoad();
            BackgroundLoad();
        }

        public void BlockLoad()
        {
            List<BlockData> blocks = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName)) // File is in the Debug.
            {
                blocks = (List<BlockData>)serializer.Deserialize(reader);
            }


            foreach (BlockData block in blocks)
            {
                switch (block.Type)
                {
                    case SpriteType.BrickBlock:
                        spriteManager.AddBlock(SpriteType.BrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.CoinBrickBlock:
                        spriteManager.AddBlock(SpriteType.CoinBrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.RedBrickBlock:
                        spriteManager.AddBlock(SpriteType.RedBrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.FlowerBrickBlock:
                        spriteManager.AddBlock(SpriteType.FlowerBrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.GreenBrickBlock:
                        spriteManager.AddBlock(SpriteType.GreenBrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.StarBrickBlock:
                        spriteManager.AddBlock(SpriteType.StarBrickBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;

                    case SpriteType.CoinQuesBlock:
                        spriteManager.AddBlock(SpriteType.CoinQuesBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.RedQuesBlock:
                        spriteManager.AddBlock(SpriteType.RedQuesBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.FlowerQuesBlock:
                        spriteManager.AddBlock(SpriteType.FlowerQuesBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.FloorBlock:
                        spriteManager.AddBlock(SpriteType.FloorBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.HiddenBlock:
                        spriteManager.AddBlock(SpriteType.HiddenBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.StairBlock:
                        spriteManager.AddBlock(SpriteType.StairBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.UsedBlock:
                        spriteManager.AddBlock(SpriteType.UsedBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.Pipe:
                        spriteManager.AddBlock(SpriteType.Pipe, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.LeftPipe:
                        spriteManager.AddBlock(SpriteType.LeftPipe, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.LongPipe:
                        spriteManager.AddBlock(SpriteType.LongPipe, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.Flagpole:
                        spriteManager.AddBlock(SpriteType.Flagpole, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.UnderBreakBlock:
                        spriteManager.AddBlock(SpriteType.UnderBreakBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                    case SpriteType.UnderFloorBlock:
                        spriteManager.AddBlock(SpriteType.UnderFloorBlock, new Vector2(block.xPosition, block.yPosition), block.Number);
                        break;
                }
            }
        }

        public void EnemyLoad()
        {
            List<EnemyData> enemies = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                enemies = (List<EnemyData>)serializer.Deserialize(reader);
            }
            foreach(EnemyData enemy in enemies)
            {
                switch (enemy.Type)
                {
                    case SpriteType.Goomba:
                        spriteManager.AddSprite(SpriteType.Goomba, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                    case SpriteType.GreenKoopa:
                        spriteManager.AddSprite(SpriteType.GreenKoopa, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                    case SpriteType.RedKoopa:
                        spriteManager.AddSprite(SpriteType.RedKoopa, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                }
            }
        }

        public void ItemLoad()
        {
            List<ItemData> items = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                items = (List<ItemData>)serializer.Deserialize(reader);
            }
            foreach(ItemData item in items)
            {
                switch (item.Type)
                {
                    case SpriteType.Coin:
                        spriteManager.AddSprite(SpriteType.Coin, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.RedMushroom:
                        spriteManager.AddSprite(SpriteType.RedMushroom, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.GreenMushroom:
                        spriteManager.AddSprite(SpriteType.GreenMushroom, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.FireFlower:
                        spriteManager.AddSprite(SpriteType.FireFlower, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Star:
                        spriteManager.AddSprite(SpriteType.Star, new Vector2(item.xPosition, item.yPosition));
                        break;

                }
            }
        }

        public void BackgroundLoad()
        {
            List<BackgroundData> backgrounds = new List<BackgroundData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BackgroundData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                backgrounds = (List<BackgroundData>)serializer.Deserialize(reader);
            }
            foreach (BackgroundData item in backgrounds)
            {
                switch (item.Type)
                {
                    case SpriteType.Cloud1:
                        spriteManager.AddBackground(SpriteType.Cloud1, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Cloud2:
                        spriteManager.AddBackground(SpriteType.Cloud2, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Cloud3:
                        spriteManager.AddBackground(SpriteType.Cloud3, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Grass1:
                        spriteManager.AddBackground(SpriteType.Grass1, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Grass2:
                        spriteManager.AddBackground(SpriteType.Grass2, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Grass3:
                        spriteManager.AddBackground(SpriteType.Grass3, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Mountain1:
                        spriteManager.AddBackground(SpriteType.Mountain1, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Mountain2:
                        spriteManager.AddBackground(SpriteType.Mountain2, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.Castle:
                        spriteManager.AddBackground(SpriteType.Castle, new Vector2(item.xPosition, item.yPosition));
                        break;
                    case SpriteType.BlackRectangle:
                        spriteManager.AddBackground(SpriteType.BlackRectangle, new Vector2(item.xPosition, item.yPosition));
                        break;
                }
            }
        }
    }
}
