﻿using Microsoft.Xna.Framework;
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
        int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }


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
            health = 10;            
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
                GetGameObject.Transform.Position = new Vector2(500);
            }
        }

        public void Move(Vector2 direction)
        {
            isMoving = true;
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
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
