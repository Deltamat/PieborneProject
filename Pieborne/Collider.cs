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
            Vector2 difference = GetGameObject.Transform.Position - otherObject.Transform.Position;
            if (Math.Abs(difference.X) > Math.Abs(difference.Y))
            {
                if (GetGameObject.CollisionBox.Center.X < otherObject.CollisionBox.Center.X) // højre til venstre
                {
                    int t = GetGameObject.CollisionBox.Right - otherObject.CollisionBox.Left;
                    GetGameObject.Transform.Translate(new Vector2(-t, 0));
                }

                else if (GetGameObject.CollisionBox.Center.X > otherObject.CollisionBox.Center.X) // venstre til højre
                {
                    int t = GetGameObject.CollisionBox.Left - otherObject.CollisionBox.Right;
                    GetGameObject.Transform.Translate(new Vector2(-t, 0));
                }
            }

            else if (Math.Abs(difference.X) < Math.Abs(difference.Y))
            {
                if (GetGameObject.CollisionBox.Center.Y < otherObject.CollisionBox.Center.Y) // oppefra ned
                {
                    int t = GetGameObject.CollisionBox.Bottom - otherObject.CollisionBox.Top;
                    GetGameObject.Transform.Translate(new Vector2(0, -t));
                }

                else if (GetGameObject.CollisionBox.Center.Y > otherObject.CollisionBox.Center.Y) // nedefra op
                {
                    int t = GetGameObject.CollisionBox.Top - otherObject.CollisionBox.Bottom;
                    GetGameObject.Transform.Translate(new Vector2(0, -t));
                }
            }
        }
    }
}
