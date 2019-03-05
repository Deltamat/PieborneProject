using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    public interface IState
    {
        void Enter(Enemy enemy);
        void Exit();
        void Execute();
    }
}
