using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class PatrolState : IState
    {
        private Enemy parent;

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            parent.directionLeft *= parent.speed;

            parent.GetGameObject.Transform.Position += (parent.directionLeft * GameWorld.deltaTime);
        }

        public void Exit()
        {
            
        }
    }
}
