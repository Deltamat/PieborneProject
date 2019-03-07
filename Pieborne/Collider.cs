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
        GameObject otherObject;

        public void Collision(GameObject otherObject)
        {
            this.otherObject = otherObject;
            if (otherObject.type == "Beer" && GetGameObject.type == "Player") 
            {
                GameWorld.gameObjectsToRemove.Add(otherObject);
                Player.Instance.Health++;
                Player.Instance.shootingSpeed *= 0.9f;
                return;
            }

            if (otherObject.type == "Beer" && GetGameObject.type == "Enemy") // gør så enemy ikke collider med beer
            {
                return;
            }

            if (GetGameObject.type == "Player" && otherObject.type == "Enemy")
            {
                Player.Instance.Health--;
            }

            if (GetGameObject.type == "Projectile") // hvis projectil rammer mur, fjern projectil
            {
                if (otherObject.type == "Terrain")
                {
                    GameWorld.gameObjectsToRemove.Add(GetGameObject);
                    return;
                }

                Projectile p = (Projectile)GetGameObject.GetComponent("Projectile");
                if (otherObject.type == "Enemy" && p.team == "player")
                {
                    Enemy enemy = (Enemy)otherObject.GetComponent("Enemy");
                    enemy.Health--;
                    GameWorld.gameObjectsToRemove.Add(GetGameObject);


                }
                else if (otherObject.type == "Player" && p.team == "enemy")
                {
                    Player.Instance.Health--;
                    GameWorld.gameObjectsToRemove.Add(GetGameObject);

                }

                return;
            }

            if (GetGameObject.type != "Projectile" && otherObject.type != "Projectile") // hvis objecterne ikke er projectile så skal collisionskoden køres
            {
                MovementCollision();
            }
        }

        private void MovementCollision()
        {
            Vector2 difference = GetGameObject.Transform.Position - otherObject.Transform.Position;

            if (Math.Abs(difference.X) > Math.Abs(difference.Y) + 1) // hvis x forskellen er størst så skal den køre højre/venstre kollision
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
                        if (otherObject.type == "Terrain" || otherObject.type == "Enemy")
                        {
                            tmp.IsFalling = false;
                        }
                    }

                else if (GetGameObject.CollisionBox.Center.Y > otherObject.CollisionBox.Center.Y) // nedefra op
                {
                    int t = GetGameObject.CollisionBox.Top - otherObject.CollisionBox.Bottom;
                    GetGameObject.Transform.Translate(new Vector2(0, -t + 1));
                    GetGameObject.Transform.verticalVelocity = 0; // få gravity til at sætte igang så snart man støder mod loftet
                }
            }
        }
    }
}
