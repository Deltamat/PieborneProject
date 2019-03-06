using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pieborne
{
    class Gravity : Component
    {
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

            if (GetGameObject.Transform.verticalVelocity < 700 && IsFalling == true)
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
