using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class ShootingState : IState
    {
        private Enemy parent;
        

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}
