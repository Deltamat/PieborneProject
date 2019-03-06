using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class ShootCommand : ICommand
    {
        Vector2 direction;

        public ShootCommand(Vector2 direction)
        {
            this.direction = direction;
        }

        public void Execute(Player p)
        {
            if (GameWorld.Instance.shootTimer > 0.5)
            {
                ProjectileFactory.Instance.Create("Kunai", Player.position, direction);
                GameWorld.Instance.shootTimer = 0;
            }
        }
    }
}
