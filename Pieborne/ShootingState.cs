using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    /// <summary>
    /// Fjende skyder efter player's position
    /// </summary>
    class ShootingState : IState
    {
        private Enemy parent;
        

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            //AI der skyder mod Player's position
            //Player.position
        }

        public void Exit()
        {
            
        }
    }
}
