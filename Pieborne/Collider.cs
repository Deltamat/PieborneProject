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
            
            if (otherObject.type == "Beer" && GetGameObject.type == "Player") 
            {
                GameWorld.gameObjectsToRemove.Add(otherObject);
                Player.Instance.Health++;
                return;
            }

            if (GetGameObject.type == "Projectile" && (otherObject.type == "Terrain" || otherObject.type == "Enemy")) // hvis projectil rammer mur, fjern projectil
            {
                GameWorld.gameObjectsToRemove.Add(GetGameObject);
                if (otherObject.type == "Enemy")
                {
                    Enemy enemy = (Enemy)otherObject.GetComponent("Enemy");
                    enemy.Health--;

                }
                return;
            }

            Vector2 difference = GetGameObject.Transform.Position - otherObject.Transform.Position;

            if (GetGameObject.type != "Projectile" && otherObject.type != "Projectile")
            {
                if (Math.Abs(difference.X) > Math.Abs(difference.Y)) // hvis x forskellen er størst så skal den køre højre/venstre kollision
                {
                    if (GetGameObject.CollisionBox.Center.X < otherObject.CollisionBox.Center.X) // højre til venstre
                    {
                        int t = GetGameObject.CollisionBox.Right - otherObject.CollisionBox.Left;
                        GetGameObject.Transform.Translate(new Vector2(-t + 1, 0));
                    }

                    else if (GetGameObject.CollisionBox.Center.X > otherObject.CollisionBox.Center.X) // venstre til højre
                    {
                        int t = GetGameObject.CollisionBox.Left - otherObject.CollisionBox.Right;
                        GetGameObject.Transform.Translate(new Vector2(-t + 1, 0));
                    }
                }

                else if (Math.Abs(difference.X) < Math.Abs(difference.Y)) // hvis y forskellen er størst skal den køre op/ned kollision
                {
                    if (GetGameObject.CollisionBox.Center.Y < otherObject.CollisionBox.Center.Y) // oppefra ned
                    {
                        int t = GetGameObject.CollisionBox.Bottom - otherObject.CollisionBox.Top;
                        GetGameObject.Transform.Translate(new Vector2(0, -t + 1));

                        Gravity tmp = (Gravity)GetGameObject.GetComponent("Gravity");
                        if (otherObject.GetComponent("Terrain") != null)
                        {
                            tmp.IsFalling = false;
                        }
                    }

                    else if (GetGameObject.CollisionBox.Center.Y > otherObject.CollisionBox.Center.Y) // nedefra op
                    {
                        int t = GetGameObject.CollisionBox.Top - otherObject.CollisionBox.Bottom;
                        GetGameObject.Transform.Translate(new Vector2(0, -t + 1));
                        GetGameObject.Transform.verticalVelocity = 0;
                    }
                }
            }
        }
    }
}
