using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class JumpCommand : ICommand
    {
        public void Execute(Player p)
        {
            p.Jump();
        }
    }
}
