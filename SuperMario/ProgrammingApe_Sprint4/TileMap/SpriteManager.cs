using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_4.TileMap
{
    public class SpriteManager
    {
        public List<EnemyEntity> enemyList;
        public List<ItemEntity> itemList;
        public List<BlockEntity> blockEntityList;
        public List<IBackground> backgroundList;

        public SpriteFactory spriteFactory;

        public SpriteManager(SpriteFactory SpriteFactory, List<EnemyEntity> enemies, List<ItemEntity> items, List<BlockEntity> blockEntities, List<IBackground> backgrounds)
        {
            spriteFactory = SpriteFactory;
            enemyList = enemies;
            itemList = items;
            blockEntityList = blockEntities;
            backgroundList = backgrounds;
        }

        public void AddSprite(SpriteType Type, Vector2 Position)
        {
            if(Type == SpriteType.Coin)
            {
                itemList.Add(new CoinEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.FireFlower)
            {
                itemList.Add(new FlowerEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.GreenMushroom)
            {
                itemList.Add(new OneupMushroomEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.RedMushroom)
            {
                itemList.Add(new PowerupMushroomEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.Star)
            {
                itemList.Add(new StarEntity(spriteFactory, Position));
            }



            else if (Type == SpriteType.Goomba)
            {
                enemyList.Add(new GoombaEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.RedKoopa)
            {
                enemyList.Add(new KoopaEntity(spriteFactory, Position));
            }
            else if (Type == SpriteType.GreenKoopa)
            {
                enemyList.Add(new KoopaEntity(spriteFactory, Position));
            }
        }

        public void AddBlock(SpriteType Type, Vector2 Position, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Type == SpriteType.BrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.emptyBrick));
                }
                else if (Type == SpriteType.CoinBrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.coinBrick));
                }
                else if (Type == SpriteType.StarBrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.starBrick));
                }
                else if (Type == SpriteType.FlowerBrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.flowerBrick));
                }
                else if (Type == SpriteType.RedBrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.redBrick));
                }
                else if (Type == SpriteType.GreenBrickBlock)
                {

                    blockEntityList.Add(new BrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), BrickState.greenBrick));
                }
                else if (Type == SpriteType.CoinQuesBlock)
                {

                    blockEntityList.Add(new QuestionBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), QuestionState.coinQues));
                }
                else if (Type == SpriteType.RedQuesBlock)
                {

                    blockEntityList.Add(new QuestionBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), QuestionState.redQues));
                }
                else if (Type == SpriteType.FlowerQuesBlock)
                {

                    blockEntityList.Add(new QuestionBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y), QuestionState.flowerQues));
                }
                else if (Type == SpriteType.HiddenBlock)
                {
                    blockEntityList.Add(new HiddenBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                }

                else if (Type == SpriteType.FloorBlock)
                {
                    blockEntityList.Add(new FloorBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                }
                else if (Type == SpriteType.StairBlock)
                {
                    blockEntityList.Add(new StairBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                }
                else if (Type == SpriteType.Pipe)
                {
                    blockEntityList.Add(new PipeEntity(spriteFactory, Position, enemyList));
                }
                else if (Type == SpriteType.LeftPipe)
                {
                    blockEntityList.Add(new LeftPipeEntity(spriteFactory, Position));
                }
                else if (Type == SpriteType.LongPipe)
                {
                    blockEntityList.Add(new LongPipeEntity(spriteFactory, Position));
                }
                else if (Type == SpriteType.Flagpole)
                {
                    blockEntityList.Add(new FlagpoleEntity(spriteFactory, Position));
                }
                else if (Type == SpriteType.UnderBreakBlock)
                {
                    blockEntityList.Add(new UnderBrickBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                }
                else if (Type == SpriteType.UnderFloorBlock)
                {
                    blockEntityList.Add(new UnderFloorBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                }


                /*   else if (Type == SpriteType.UsedBlock)
                   {
                       blockEntityList.Add(new FloorBlockEntity(spriteFactory, new Vector2(Position.X + i * 32, Position.Y)));
                   }*/
            }
        }

        public void AddBackground(SpriteType Type, Vector2 Position)
        {
            if (Type == SpriteType.Cloud1)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.cloud1, Position));
            }
            else if (Type == SpriteType.Cloud2)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.cloud2, Position));
            }
            else if (Type == SpriteType.Cloud3)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.cloud3, Position));
            }
            else if (Type == SpriteType.Grass1)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.grass1, Position));
            }
            else if (Type == SpriteType.Grass2)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.grass2, Position));
            }
            else if (Type == SpriteType.Grass3)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.grass3, Position));
            }
            else if (Type == SpriteType.Mountain1)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.mountain1, Position));
            }
            else if (Type == SpriteType.Mountain2)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.mountain2, Position));
            }
            else if (Type == SpriteType.Castle)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.castle, Position));
            }
            else if (Type == SpriteType.BlackRectangle)
            {
                backgroundList.Add(spriteFactory.createBackground(SpriteFactory.sprites.blackRectangle, Position));
            }
        }
    }
}
