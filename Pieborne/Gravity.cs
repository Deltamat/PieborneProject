using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pieborne
{
    public class Gravity : Component
    {
        double gravityTimer;

        bool isFalling = true;
        public bool IsFalling
        {
            get
            {
                return isFalling;
            }
            set
            {
                isFalling = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //if (gravityTimer < 1 && isFalling == true)
            //{
            //    GetGameObject.Transform.verticalVelocity++;
            //    gravityTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //}

            //GetGameObject.Transform.Translate(new Vector2(0, GetGameObject.Transform.verticalVelocity * 0.5f));

            //if (isFalling == false)
            //{
            //    GetGameObject.Transform.verticalVelocity = 13.37f;
            //}

            if (GetGameObject.Transform.verticalVelocity < 1000 && IsFalling == true)
            {
                GetGameObject.Transform.verticalVelocity += (float)Math.Pow(4,2);
            }

            GetGameObject.Transform.Translate(new Vector2(0, GetGameObject.Transform.verticalVelocity * GameWorld.deltaTime));

            if (isFalling == false)
            {
                GetGameObject.Transform.verticalVelocity = 200f;
            }
        }
    }
}
