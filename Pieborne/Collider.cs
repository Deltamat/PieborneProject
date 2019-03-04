using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class Collider : Component
    {
        public void Collision(GameObject otherObject)
        {
            if (GetGameObject.CollisionBox.Center.X < otherObject.CollisionBox.Center.X) // højre til venstre
            {
                int t = GetGameObject.CollisionBox.Right - otherObject.CollisionBox.Left;
                GetGameObject.Transform.Translate(new Vector2(t, 0));
            }

            if (GetGameObject.CollisionBox.Center.X > otherObject.CollisionBox.Center.X) // venstre til højre
            {
                int t = GetGameObject.CollisionBox.Left - otherObject.CollisionBox.Right;
                GetGameObject.Transform.Translate(new Vector2(t, 0));
            }

        }
    }
}
