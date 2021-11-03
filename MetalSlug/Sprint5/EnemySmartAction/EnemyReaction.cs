using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    public class EnemyReaction
    {
        private Game1 Game;
        private WarriorEntity TargetWarrior;
        public EnemyReaction(Game1 game)
        {
            Game = game;
        }

        public void EnemySmartReaction(WarriorEntity marco, WarriorEntity tarma, List<EnemyEntity> enemies)
        {
            foreach(EnemyEntity enemy in enemies)
            {
                double MarcoDistance = Math.Sqrt((enemy.Position.X - marco.Position.X) * (enemy.Position.X - marco.Position.X)
                    + (enemy.Position.Y - marco.Position.Y) * (enemy.Position.Y - marco.Position.Y));
                double TarmaDistance = Math.Sqrt((enemy.Position.X - tarma.Position.X) * (enemy.Position.X - tarma.Position.X)
                    + (enemy.Position.Y - tarma.Position.Y) * (enemy.Position.Y - tarma.Position.Y));
                int Distance;
                if (enemy.EnemyType == EnemyType.Soldier || enemy.EnemyType == EnemyType.Captain)
                    Distance = 200;
                else if (enemy.EnemyType == EnemyType.Bunker)
                    Distance = 300;
                else
                    Distance = 500;

                if ((MarcoDistance < Distance && marco.HealthPoint > 0) || (TarmaDistance < Distance && tarma.HealthPoint > 0))
                {
                    if (MarcoDistance <= TarmaDistance)
                    {
                        if (marco.HealthPoint > 0)
                            TargetWarrior = marco;
                        else
                            TargetWarrior = null;
                    }
                    else
                    {
                        if (tarma.HealthPoint > 0)
                            TargetWarrior = tarma;
                        else
                            TargetWarrior = null;
                    }

                    if(TargetWarrior != null)
                    {
                        enemy.EnemyActionState.FireTransition();
                        if (TargetWarrior.Position.X <= enemy.Position.X)
                            enemy.EnemyActionState.FaceLeftTransition();
                        else
                            enemy.EnemyActionState.FaceRightTransition();

                        if (enemy.FireCD == 0 && !enemy.isDead)
                            enemy.Fire();
                    }
                    else
                    {
                        if (enemy.EnemyType == EnemyType.Soldier || enemy.EnemyType == EnemyType.Captain)
                            enemy.EnemyActionState.RunningTransition();
                        else
                            enemy.EnemyActionState.IdleTransition();
                    }
                }
                else
                {
                    if (enemy.EnemyType == EnemyType.Soldier || enemy.EnemyType == EnemyType.Captain)
                        enemy.EnemyActionState.RunningTransition();
                    else
                        enemy.EnemyActionState.IdleTransition();
                }
            }
        }
    }
}
