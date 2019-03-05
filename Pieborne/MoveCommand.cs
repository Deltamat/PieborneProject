using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class MoveCommand : ICommand
    {
        Vector2 direction;

        public MoveCommand(Vector2 direction)
        {
            this.direction = direction;
        }

        public void Execute(Player p)
        {
            p.Move(direction);
        }
    }
}
