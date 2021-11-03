using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class EnemyChanging
    {
        private EnemyEntity EnemyEntity { get; set; }

        public EnemyChanging(EnemyEntity enemy)
        {
            EnemyEntity = enemy;
        }

        public void Update()
        {

            if (EnemyEntity.EnemyState_Enum == EnemyState_enum.GoombaDead)
            {
                EnemyEntity.Sprite = EnemyEntity.SpriteFactory.createEnemy(SpriteFactory.sprites.deadGoomba);
            }
            else if (EnemyEntity.EnemyState_Enum == EnemyState_enum.KoopaAlive)
            {
                EnemyEntity.Sprite = EnemyEntity.SpriteFactory.createEnemy(SpriteFactory.sprites.greenKoopa);
                EnemyEntity._position.Y -= 36;
            }
            else if (EnemyEntity.EnemyState_Enum == EnemyState_enum.KoopaShell)
            {
                EnemyEntity.Sprite = EnemyEntity.SpriteFactory.createEnemy(SpriteFactory.sprites.koopaShell);
                EnemyEntity._position.Y += 36;
            }
        }
    }
}
