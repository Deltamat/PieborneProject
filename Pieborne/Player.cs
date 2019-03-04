using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    public class Player : Component
    {
        public static Vector2 position;
        float speed;
        Vector2 startPos;
        double gravityTimer;
        int gravityStrength;

        public Player(float speed, Vector2 startPosition)
        {
            this.speed = speed;
            startPos = startPosition;
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            GetGameObject.Transform.Position = startPos;
        }

        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);
            //position = GetGameObject().Transform.Position; //så andre klasser kan se på player position, 
            //if (gravityTimer < 2)
            //{
            //    gravityStrength++;
            //    gravityTimer += gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //GetGameObject().Transform.Translate(new Vector2(0, gravityStrengt * 0.1f));

            //GetGameObject().Transform.Translate(new Vector2(0, (float)(9.80612f - 0.025865f * Math.Cos(2 * 70) + 0.000058f * Math.Cos(2 * 70))));
        }

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GetGameObject.Transform.Position += (velocity * GameWorld.deltaTime);
        }
    }
}
