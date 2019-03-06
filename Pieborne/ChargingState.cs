using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    
    /// <summary>
    /// kigger efter player's position for derefter at "hoppe" i lige linje efter player's 
    /// position efter en kort "charge up"
    /// </summary>
    class ChargingState : IState
    {
        private Vector2 direction;
        private Enemy parent;

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// ganger parent speed med 3 (indtil videre) for at få en "charge effect"
        /// </summary>
        public void Execute()
        {
            if (Player.position != Vector2.Zero)
            {
                direction = Player.position;
                direction.Normalize();
            }
            direction *= parent.speed * 3;
            parent.GetGameObject.Transform.Translate(direction * GameWorld.deltaTime);
        }

        public void Exit()
        {
            
        }
    }
}
