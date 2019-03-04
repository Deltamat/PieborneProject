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


        static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(1, Vector2.Zero);
                }
                return instance;
            }
        }

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
            position = GetGameObject.Transform.Position; //så andre klasser kan se på player position, 
            

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

        public void Jump()
        {
            Gravity tmp = (Gravity)GetGameObject.GetComponent("Gravity");
            if (tmp.IsFalling == false)
            {
                GetGameObject.Transform.verticalVelocity = new Vector2(0, -1000);
            }
        }
    }
}
