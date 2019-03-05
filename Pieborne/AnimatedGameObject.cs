using Microsoft.Xna.Framework;
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
                return new Rectangle((int)(Transform.Position.X - 50 * 0.5), (int)(Transform.Position.Y - 50 * 0.5), 50, 50);
            }
        }

        Rectangle[,] animationRectangles = new Rectangle[10,6];
        float animationFPS = 10;
        int currentAnimationIndexY = 0;
        int currentAnimationIndexX = 0;
        private double timeElapsed = 0;
        SpriteRenderer sr;

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
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndexX = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndexX == 10)
            {
                currentAnimationIndexX = 0;
                timeElapsed = 0;
                
                currentAnimationIndexY++;
                if (currentAnimationIndexY == 6)
                {
                    currentAnimationIndexY = 0;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);

            if (sr != null)
            {
                spriteBatch.Draw(
                sr.sprite,
                Transform.Position,
                animationRectangles[currentAnimationIndexX, currentAnimationIndexY],
                Color.White,
                0,
                new Vector2(animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Width * 0.5f, animationRectangles[currentAnimationIndexX, currentAnimationIndexY].Height * 0.5f),
                1f,
                SpriteEffects.None,
                0.9f);
            }
            

        }
    }
}
