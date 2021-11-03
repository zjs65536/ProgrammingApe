using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class MapManager
    {
        private Game1 Game;
        public List<EnemyEntity> enemyList;
        public List<BlockEntity> blockList;
        private string fileName;

        public MapManager(Game1 game, string fileName ,List<EnemyEntity> enemies, List<BlockEntity> blocks)
        {
            Game = game;
            enemyList = enemies;
            blockList = blocks;
            this.fileName = fileName;
        }

        public void Load()
        {
            LoadBlock();
            LoadEnemy();
        }

        public void LoadBlock()
        {
            List<BlockData> blocks = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName)) // File is in the Debug.
            {
                blocks = (List<BlockData>)serializer.Deserialize(reader);
            }

            foreach(BlockData block in blocks)
            {
                switch (block.Type)
                {
                    case SpriteType.Wood:
                        AddBlock(SpriteType.Wood, new Vector2(block.xPosition, block.yPosition), block.xCount, block.yCount);
                        break;
                    case SpriteType.Stone:
                        AddBlock(SpriteType.Stone, new Vector2(block.xPosition, block.yPosition), block.xCount, block.yCount);
                        break;
                }
            }
        }

        public void LoadEnemy()
        {
            List<EnemyData> enemies = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                enemies = (List<EnemyData>)serializer.Deserialize(reader);
            }
            foreach (EnemyData enemy in enemies)
            {
                switch (enemy.Type)
                {
                    case SpriteType.Boss:
                        AddEnemy(SpriteType.Boss, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                    case SpriteType.Bunker:
                        AddEnemy(SpriteType.Bunker, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                    case SpriteType.Captain:
                        AddEnemy(SpriteType.Captain, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                    case SpriteType.Soldier:
                        AddEnemy(SpriteType.Soldier, new Vector2(enemy.xPosition, enemy.yPosition));
                        break;
                }
            }
        }

        public void AddBlock(SpriteType Type, Vector2 Position, int xCount, int yCount)
        {
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    if (Type == SpriteType.Stone)
                    {
                        blockList.Add(new StoneBlockEntity(Game, new Vector2(Position.X + x * 30, Position.Y + y * 30)));
                    }
                    else if (Type == SpriteType.Wood)
                    {
                        blockList.Add(new WoodenBoxEntity(Game, new Vector2(Position.X + x * 30, Position.Y + y * 30)));
                    }
                }
            }
        }

        public void AddEnemy(SpriteType Type, Vector2 Position)
        {
            if(Type == SpriteType.Boss)
            {
                enemyList.Add(new BossEntity(Game, Position, Game.Bullets));
            }
            else if(Type == SpriteType.Bunker)
            {
                enemyList.Add(new BunkerEntity(Game, Position, Game.Bullets));
            }
            else if(Type == SpriteType.Captain)
            {
                enemyList.Add(new CaptainEntity(Game, Position, Game.Bullets));
            }
            else if(Type == SpriteType.Soldier)
            {
                enemyList.Add(new SoldierEntity(Game, Position, Game.Bullets));
            }
        }

    }
}
