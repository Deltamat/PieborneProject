using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    abstract class Factory
    {
        abstract public GameObject Create(string type, Vector2 startPos);
    }
}
