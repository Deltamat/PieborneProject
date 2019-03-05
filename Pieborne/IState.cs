using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    public interface IState
    {
        void Enter(GameObject gameObject);
        void Exit();
        void Execute();
    }
}
