﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    public class AnimatedGameObject : GameObject
    {
        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(Transform.Position.X - 28 * 0.5), (int)(Transform.Position.Y - 28 * 0.5), 28, 28);
            }
        }

        Rectangle[,] animationRectangles = new Rectangle[10,6];
        public float animationFPS = 10;
        int currentAnimationIndexY = 0;
        int currentAnimationIndexX = 0;
        int currentAnimation;
        private double timeElapsed = 0;
        private new SpriteRenderer sr;
        public string animationType;
        private bool firstTime = true;
        public SpriteEffects facing;
        double immortalFlashingTimer;

        public AnimatedGameObject(int frameCount, float animationFPS) : base()
        {            
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[10, 6];
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    animationRectangles[i, j] = new Rectangle(i * (500 / 10), 50 * j, (500 / 10), 300 / 6);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (sr == null)
            {
                sr = (SpriteRenderer)GetComponent("SpriteRenderer");
            }
            
            base.Update(gameTime);

            switch (animationType)
            {
                case "idle":
                    Idle(gameTime);
                    break;
                case "walk":
                    Walk(gameTime);
                    break;
                case "jump":
                    Jump(gameTime);
                    break;
                case "throw":
                    Throw(gameTime);
                    break;
                case "punch":
                    Punch(gameTime);
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (sr != null)
            {                
                if (Player.Instance.immortal == true) //Makes the player flash while immortal
                {
                    if (immortalFlashingTimer <= 0.15)
                    {
                        immortalFlashingTimer += GameWorld.deltaTime;
                    }
                    if (immortalFlashingTimer > 0.1)
                    {
                        spriteBatch.Draw(
                                sr.sprite,
                                Transform.Position,
                                animationRectangles[currentAnimationIndexX, currentAnimationIndexY],
                                Color.Red,
                                0,
                                new Vector2(animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Width * 0.5f, animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Height * 0.5f),
                                1f,
                                facing,
                                0.9f);
                    }
                    if (immortalFlashingTimer > 0.15)
                    {
                        immortalFlashingTimer = 0;
                    }
                }
                else //Draws the player normally
                {
                    spriteBatch.Draw(sr.sprite, Transform.Position, animationRectangles[currentAnimationIndexX, currentAnimationIndexY], Color.White, 0, new Vector2(animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Width * 0.5f, animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Height * 0.5f), 1f, facing, 0.9f);
                }
            }
        }

        /// <summary>
        /// Plays the idle animation
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void Idle(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimation = (int)(timeElapsed * animationFPS);
            switch (currentAnimation)
            {
                case 0:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
                case 1:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 2;
                    break;
                case 2:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
                case 3:
                    currentAnimationIndexX = 1;
                    currentAnimationIndexY = 2;
                    break;
            }
            if (currentAnimation > 3)
            {
                currentAnimation = 0;
                timeElapsed = 0;
            }
        }

        /// <summary>
        /// Plays the walking animation
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void Walk(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimation = (int)(timeElapsed * animationFPS);
            switch (currentAnimation)
            {
                case 0:
                    currentAnimationIndexX = 3;
                    currentAnimationIndexY = 0;
                    break;
                case 1:
                    currentAnimationIndexX = 4;
                    currentAnimationIndexY = 0;
                    break;
                case 2:
                    currentAnimationIndexX = 1;
                    currentAnimationIndexY = 2;
                    break;
            }
            if (currentAnimation > 2)
            {
                currentAnimation = 0;
                timeElapsed = 0;
            }
        }

        /// <summary>
        /// Plays the jumping animation
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void Jump(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimation = (int)(timeElapsed * animationFPS);
            switch (currentAnimation)
            {
                case 0:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
                case 1:
                    currentAnimationIndexX = 7;
                    currentAnimationIndexY = 0;
                    break;
                case 2:
                    currentAnimationIndexX = 9;
                    currentAnimationIndexY = 2;
                    break;
                case 3:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 3;
                    break;
            }
            if (currentAnimation > 3)
            {
                currentAnimation = 0;
                timeElapsed = 0.2;
            }
        }

        /// <summary>
        /// Plays the throwing animation
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void Throw(GameTime gameTime)
        {
            if (firstTime == true)
            {
                timeElapsed = 0;
                firstTime = false;
            }
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimation = (int)(timeElapsed * animationFPS);
            switch (currentAnimation)
            {
                case 0:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
                case 1:
                    currentAnimationIndexX = 6;
                    currentAnimationIndexY = 1;
                    break;
                case 2:
                    currentAnimationIndexX = 7;
                    currentAnimationIndexY = 1;
                    break;
                case 3:
                    currentAnimationIndexX = 6;
                    currentAnimationIndexY = 1;
                    break;
                case 4:
                    currentAnimationIndexX = 8;
                    currentAnimationIndexY = 1;
                    break;
                case 5:
                    currentAnimationIndexX = 9;
                    currentAnimationIndexY = 1;
                    break;
            }
            if (currentAnimation > 5)
            {
                currentAnimation = 0;
                timeElapsed = 0;
                firstTime = true;
            }
        }

        /// <summary>
        /// Plays the punching animation
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        private void Punch(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimation = (int)(timeElapsed * animationFPS);
            switch (currentAnimation)
            {
                case 0:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
                case 1:
                    currentAnimationIndexX = 6;
                    currentAnimationIndexY = 1;
                    break;
                case 2:
                    currentAnimationIndexX = 7;
                    currentAnimationIndexY = 1;
                    break;
                case 3:
                    currentAnimationIndexX = 6;
                    currentAnimationIndexY = 3;
                    break;
                case 4:
                    currentAnimationIndexX = 7;
                    currentAnimationIndexY = 3;
                    break;
                case 5:
                    currentAnimationIndexX = 6;
                    currentAnimationIndexY = 1;
                    break;
                case 6:
                    currentAnimationIndexX = 8;
                    currentAnimationIndexY = 3;
                    break;
                case 7:
                    currentAnimationIndexX = 9;
                    currentAnimationIndexY = 3;
                    break;
                case 8:
                    currentAnimationIndexX = 0;
                    currentAnimationIndexY = 0;
                    break;
            }
            if (currentAnimation > 8)
            {
                currentAnimation = 0;
                timeElapsed = 0;
            }
        }
    }
}
