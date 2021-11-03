using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class EnemyChanging
    {
        private EnemyEntity EnemyEntity;
        public EnemyChanging(EnemyEntity enemy)
        {
            EnemyEntity = enemy;
        }

        public void Update()
        {
            if(EnemyEntity.EnemyFacing == EnemyFacing.Left)
            {
                if(EnemyEntity.EnemyType == EnemyType.Soldier)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierDie);
                    if(EnemyEntity.EnemyState == EnemyState.Fire)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierFireLeft);
                        EnemyEntity.Position += new Vector2(-5, 0);
                    }
                    if (EnemyEntity.EnemyState == EnemyState.Run)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierRunLeft);
                        EnemyEntity.Position += new Vector2(5, 0);
                    }
                }
                if (EnemyEntity.EnemyType == EnemyType.Captain)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainFireLeft);
                        EnemyEntity.Position += new Vector2(-5, 0);
                    }
                    if (EnemyEntity.EnemyState == EnemyState.Run)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainRunLeft);
                        EnemyEntity.Position += new Vector2(5, 0);
                    }
                }
                if(EnemyEntity.EnemyType == EnemyType.Bunker)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerFireLeft);
                    if (EnemyEntity.EnemyState == EnemyState.Idle)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerIdleLeft);
                }
                if(EnemyEntity.EnemyType == EnemyType.Boss)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossFireLeft);
                    if (EnemyEntity.EnemyState == EnemyState.Idle)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossIdleLeft);
                }
            }
            else
            {
                if (EnemyEntity.EnemyType == EnemyType.Soldier)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierFireRight);
                        EnemyEntity.Position += new Vector2(5, 0);
                    }
                    if (EnemyEntity.EnemyState == EnemyState.Run)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.SoldierRunRight);
                        EnemyEntity.Position += new Vector2(-5, 0);
                    }
                }
                if (EnemyEntity.EnemyType == EnemyType.Captain)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainFireRight);
                        EnemyEntity.Position += new Vector2(5, 0);
                    }
                    if (EnemyEntity.EnemyState == EnemyState.Run)
                    {
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.CaptainRunRight);
                        EnemyEntity.Position += new Vector2(-5, 0);
                    }
                }
                if (EnemyEntity.EnemyType == EnemyType.Bunker)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerFireRight);
                    if (EnemyEntity.EnemyState == EnemyState.Idle)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BunkerIdleRight);
                }
                if (EnemyEntity.EnemyType == EnemyType.Boss)
                {
                    if (EnemyEntity.EnemyState == EnemyState.Die)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossDie);
                    if (EnemyEntity.EnemyState == EnemyState.Fire)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossFireRight);
                    if (EnemyEntity.EnemyState == EnemyState.Idle)
                        EnemyEntity.Sprite = EnemyEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.BossIdleRight);
                }
            }
        }
    }
}
