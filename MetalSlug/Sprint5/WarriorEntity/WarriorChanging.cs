using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    public class WarriorChanging
    {
        private WarriorEntity WarriorEntity;
        public WarriorChanging(WarriorEntity warrior)
        {
            WarriorEntity = warrior;
        }

        public void Update()
        {
            if (WarriorEntity.WarriorName == WarriorName.Marco) // Marco
            {
                if (WarriorEntity.WarriorFacing == WarriorFacing.Left)
                {
                    if(WarriorEntity.WarriorState == WarriorState.Celebrate)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoCelebrate);
                    }
                    if(WarriorEntity.WarriorState == WarriorState.Dead)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoDie);
                    }
                    if(WarriorEntity.WarriorState == WarriorState.Jump)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoJumpLeft);
                    }
                    if(WarriorEntity.WarriorState == WarriorState.Crounch)
                    {
                        if(WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolCrouchLeft);
                        }
                        if(WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunCrouchLeft);
                        }
                        if(WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunCrouchLeft);
                        }
                    }
                    if(WarriorEntity.WarriorState == WarriorState.Stand)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolIdleLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunIdleLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunIdleLeft);
                        }
                    }
                    if(WarriorEntity.WarriorState == WarriorState.Run)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolRunLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunRunLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunRunLeft);
                        }
                    }
                }
                else
                {
                    if (WarriorEntity.WarriorState == WarriorState.Celebrate)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoCelebrate);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Dead)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoDie);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Jump)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoJumpRight);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Crounch)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolCrouchRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunCrouchRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunCrouchRight);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Stand)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolIdleRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunIdleRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunIdleRight);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Run)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoPistolRunRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoMachineGunRunRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.MarcoLaserGunRunRight);
                        }
                    }
                }
            }
            else // Tarma
            {
                if (WarriorEntity.WarriorFacing == WarriorFacing.Left)
                {
                    if (WarriorEntity.WarriorState == WarriorState.Celebrate)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaCelebrate);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Dead)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaDie);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Jump)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaJumpLeft);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Crounch)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolCrouchLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunCrouchLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunCrouchLeft);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Stand)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolIdleLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunIdleLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunIdleLeft);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Run)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolRunLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunRunLeft);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunRunLeft);
                        }
                    }
                }
                else
                {
                    if (WarriorEntity.WarriorState == WarriorState.Celebrate)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaCelebrate);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Dead)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaDie);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Jump)
                    {
                        WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaJumpRight);
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Crounch)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolCrouchRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunCrouchRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunCrouchRight);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Stand)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolIdleRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunIdleRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunIdleRight);
                        }
                    }
                    if (WarriorEntity.WarriorState == WarriorState.Run)
                    {
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.Pistal)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaPistolRunRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.machineGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaMachineGunRunRight);
                        }
                        if (WarriorEntity.WarriorWeaponState == WarriorWeaponState.lazerGun)
                        {
                            WarriorEntity.Sprite = WarriorEntity.Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.TarmaLaserGunRunRight);
                        }
                    }
                }
            }

            if (WarriorEntity.previousWarriorState == WarriorState.Crounch)
            {
                if(WarriorEntity.WarriorName == WarriorName.Marco)
                    WarriorEntity.Position += new Vector2(0, -16);
                else
                    WarriorEntity.Position += new Vector2(0, -12);
            }

            if (WarriorEntity.WarriorState == WarriorState.Crounch)
            {
                if(WarriorEntity.WarriorName == WarriorName.Marco)
                    WarriorEntity.Position += new Vector2(0, 16);
                else
                    WarriorEntity.Position += new Vector2(0, 12);
            }
        }
    }
}
