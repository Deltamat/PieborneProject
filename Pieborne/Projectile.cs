using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class Projectile : Component
    {
        Vector2 direction;
        float speed;
        public string team;
        double aliveTimer;

        public Projectile(Vector2 direction, float speed, string team)
        {
            this.direction = direction;
            this.speed = speed;
            this.team = team;
        }

        public override void Update(GameTime gameTime)
        {
            aliveTimer += GameWorld.deltaTime;
            if (aliveTimer > 0.8)
            {
                GameWorld.gameObjectsToRemove.Add(GetGameObject);
            }
            // kommer projectilet ud for skærmen fjernes det
            if (GetGameObject.Transform.Position.X < 0 || GetGameObject.Transform.Position.Y < 0 || GetGameObject.Transform.Position.X > GameWorld.Instance.ScreenSize.Right || GetGameObject.Transform.Position.Y > GameWorld.Instance.ScreenSize.Bottom)
            {
                GameWorld.gameObjectsToRemove.Add(GetGameObject);
            }

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            // rotate sprite
            if (direction == new Vector2(1,0))
            {
                GetGameObject.sr.rotation = MathHelper.ToRadians(0);
            }
            else if (direction == new Vector2(-1, 0))
            {
                GetGameObject.sr.rotation = MathHelper.ToRadians(180);
            }
            else if (direction == new Vector2(0, 1))
            {
                GetGameObject.sr.rotation = MathHelper.ToRadians(90);
            }
            else if (direction == new Vector2(0, -1))
            {
                GetGameObject.sr.rotation = MathHelper.ToRadians(270);
            }

            direction *= speed;
            GetGameObject.Transform.Translate(direction * GameWorld.deltaTime);
        }
    }
}
