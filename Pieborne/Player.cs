using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        Gravity tmp;
        bool isMoving;
        public bool shooting;
        double animationCooldown;
        double immortalTimer;
        public bool immortal = false;

        int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < health && immortal == false)
                {
                    immortal = true;
                    health = value;
                }
                else if (value > health)
                {
                    health = value;
                }
            }
        }


        static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(300, Vector2.Zero);
                }
                return instance;
            }
        }

        private Player(float speed, Vector2 startPosition)
        {
            this.speed = speed;
            startPos = startPosition;
            health = 5;            
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            GetGameObject.Transform.Position = startPos;
        }

        public override void Update(GameTime gameTime)
        {
            if (immortal == true)
            {
                immortalTimer += GameWorld.deltaTime;
            }
            if (immortalTimer > 0.75)
            {
                immortal = false;
                immortalTimer = 0;
            }

            InputHandler.Instance.Execute(this);
            position = GetGameObject.Transform.Position; //så andre klasser kan se på player position, 
            tmp = (Gravity)GetGameObject.GetComponent("Gravity");


            if (shooting == true)
            {
                animationCooldown += gameTime.ElapsedGameTime.TotalSeconds;
                GetAnimatedGameObject.animationType = "throw";
                if (animationCooldown > 0.5)
                {
                    shooting = false;
                    animationCooldown = 0;
                }
            }
            else if (tmp.IsFalling == true)
            {
                GetAnimatedGameObject.animationType = "jump";
            }
            else if (isMoving == true)
            {
                GetAnimatedGameObject.animationType = "walk";
            }
            else
            {
                GetAnimatedGameObject.animationType = "idle";
            }
            isMoving = false;

            if (GetGameObject.Transform.Position.Y > 1080)
            {
                GetGameObject.Transform.Position = new Vector2(100, 950);
            }
        }

        public void Move(Vector2 direction)
        {
            isMoving = true;
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            if (direction == new Vector2(-1,0))
            {
                GetAnimatedGameObject.facing = SpriteEffects.FlipHorizontally;
            }
            else if (direction == new Vector2(1, 0))
            {
                GetAnimatedGameObject.facing = SpriteEffects.None;
            }
            direction *= speed;

            GetGameObject.Transform.Translate(direction * GameWorld.deltaTime);
        }

        public void Jump()
        {
            if (tmp.IsFalling == false)
            {
                GetGameObject.Transform.verticalVelocity = -700;
                tmp.IsFalling = true;
            }
        }
    }
}
