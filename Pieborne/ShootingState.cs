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
        double reloadTimer;

        public void Enter(Enemy parent)
        {
            this.parent = parent;
        }

        public void Execute()
        {
            reloadTimer += GameWorld.deltaTime;
            if (Player.position != Vector2.Zero)
            {
                direction = Player.position - parent.GetGameObject.Transform.Position;
                direction.Normalize();
            }
            //AI der skyder mod Player's position
            if (reloadTimer > 1f)
            {
                ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);
                reloadTimer = 0;
            }
        }

        public void Exit()
        {
            
        }
    }
}
