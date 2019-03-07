using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    /// <summary>
    /// går til højre og venstre skiftevis henholdsvis i 2 sekunder hver vej
    /// </summary>
    class PatrolState : IState
    {
        private Enemy parent;
        private float patrolTimer = 0;

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            if (Vector2.Distance(parent.GetGameObject.Transform.Position, Player.position) < 300 && parent.GetType() == typeof(EnemyRanged))
            {
                parent.ChangeState(new ShootingState());
            }
            else if(Vector2.Distance(parent.GetGameObject.Transform.Position, Player.position) < 250 && parent.GetType() == typeof(EnemyMelee))
            {
                parent.ChangeState(new ChargingState());
            }
            if (Player.position.X > 1152 && parent.GetType() == typeof(EnemyBoss))
            {
                parent.ChangeState(new BossState());
            }
            patrolTimer += GameWorld.deltaTime;
            //move to the left for 2 seconds
            if (patrolTimer < 2)
            {
                parent.directionLeft.Normalize();
                parent.directionLeft *= parent.speed;
                parent.GetGameObject.Transform.Translate(parent.directionLeft * GameWorld.deltaTime);
            }
            //resets timer so the enemy can move left for 2 seconds again
            else if (patrolTimer > 4)
            {
                patrolTimer = 0;
            }
            //moves to the right for 2 seconds
            else if (patrolTimer > 2)
            {
                parent.directionRight.Normalize();
                parent.directionRight *= parent.speed;
                parent.GetGameObject.Transform.Translate(parent.directionRight * GameWorld.deltaTime);
            }
        }

        public void Exit()
        {
            
        }
    }
}
