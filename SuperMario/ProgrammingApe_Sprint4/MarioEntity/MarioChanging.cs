using Controller_Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class MarioChanging
    {
        private MarioEntity MarioEntity { get; set; }

        public MarioChanging(MarioEntity mario)
        {
            MarioEntity = mario;
        }

        public void Update()
        {          
            if (MarioEntity.MarioStatus_Enum == MarioStatus_enum.Standard)
            {
                if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Idle || MarioEntity.MarioActionState_Enum == MarioActionState_enum.Crouching)
                {
                    if(MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite =  MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioIdleLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioIdleRight);
                    }
                    
                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Jumping)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioJumpLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioJumpRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Running)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioRunLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioRunRight);
                    }

                }
                else if(MarioEntity.MarioActionState_Enum == MarioActionState_enum.Flag)
                {
                    MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.flagSmallMario);
                }
            }
            if (MarioEntity.MarioStatus_Enum == MarioStatus_enum.Super)
            {
                if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Idle)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioIdleLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioIdleRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Crouching)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioCrouchLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioCrouchRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Jumping)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioJumpLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioJumpRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Running)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioRunLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.bigMarioRunRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Flag)
                {
                    MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.flagBigMario);
                }
            }
            else if(MarioEntity.MarioStatus_Enum == MarioStatus_enum.Fire)
            {
                if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Idle)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioIdleLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioIdleRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Crouching)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioCrouchLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioCrouchRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Jumping)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioJumpLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioJumpRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Running)
                {
                    if (MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioRunLeft);
                    }
                    else
                    {
                        MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.fireMarioRunRight);
                    }

                }
                else if (MarioEntity.MarioActionState_Enum == MarioActionState_enum.Flag)
                {
                    MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.flagFireMario);
                }

            }
            else if (MarioEntity.MarioStatus_Enum == MarioStatus_enum.Dead)
                MarioEntity.Sprite = MarioEntity.SpriteFactory.createSprite(SpriteFactory.sprites.marioDead);
        }
    }
}
