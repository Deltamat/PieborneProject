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
        Gravity fetcher;
        bool isMoving;
        public bool shooting;
        double animationCooldown;
        double immortalTimer;
        public bool immortal = false;
        public float shootingSpeed = 0.5f;
        public double shootTimer;

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
            //Controls temporary immortality
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
            position = GetGameObject.Transform.Position; 
            fetcher = (Gravity)GetGameObject.GetComponent("Gravity");

            //Shooting cooldown
            if (shootTimer < shootingSpeed)
            {
                shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }

            //Controls animations
            if (shooting == true) //Shooting animation
            {
                animationCooldown += gameTime.ElapsedGameTime.TotalSeconds;
                GetAnimatedGameObject.animationType = "throw";
                if (animationCooldown > 0.5)
                {
                    shooting = false;
                    animationCooldown = 0;
                }
            }
            else if (fetcher.IsFalling == true) //Jumping animation
            {
                GetAnimatedGameObject.animationType = "jump";
            }
            else if (isMoving == true) //Walking animation
            {
                GetAnimatedGameObject.animationType = "walk";
            }
            else //Idle animation
            {
                GetAnimatedGameObject.animationType = "idle";
            }
            isMoving = false;

            //If the player falls out of the screen, teleports them back to the start
            if (GetGameObject.Transform.Position.Y > 1080)
            {
                GetGameObject.Transform.Position = new Vector2(100, 950);
            }
        }

        /// <summary>
        /// Calculates the direction and speed the player should move
        /// </summary>
        /// <param name="direction">The direction the player should move in</param>
        public void Move(Vector2 direction)
        {
            isMoving = true; //Sets a flag that the player is moving

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            //Checks which way the player is moving and changes which way the sprite is facing
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

        /// <summary>
        /// If the player is not falling, gives them an upward velocity
        /// </summary>
        public void Jump()
        {
            if (fetcher.IsFalling == false)
            {
                GetGameObject.Transform.verticalVelocity = -700;
                fetcher.IsFalling = true;
            }
        }
    }
}
