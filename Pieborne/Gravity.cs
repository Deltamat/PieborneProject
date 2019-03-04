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
            if (GetGameObject.Transform.verticalVelocity.Y < 20 && isFalling == true)
            {
                GetGameObject.Transform.verticalVelocity.Y++;
                
            }

            GetGameObject.Transform.Translate(new Vector2(0, GetGameObject.Transform.verticalVelocity.Y * 0.5f));

            if (isFalling == false)
            {
                GetGameObject.Transform.verticalVelocity.Y = 13.37f;
            }
            
        }
    }
}
