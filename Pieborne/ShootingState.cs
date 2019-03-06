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
        private Vector2 direction;

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            if (Player.position != Vector2.Zero)
            {
                direction = Player.position;
                direction.Normalize();
            }
            //AI der skyder mod Player's position
            ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position, direction);
        }

        public void Exit()
        {
            
        }
    }
}
