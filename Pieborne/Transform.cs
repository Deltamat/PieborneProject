using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{

    public class Transform : Component
    {
        public float verticalVelocity = 200;
        public Vector2 velocity;

        Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Transform(GameObject gameObject, Vector2 position)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {
            velocity = translation;
            Gravity fetcher = (Gravity)GetGameObject.GetComponent("Gravity");
            if (fetcher.IsFalling == false)
            {
                velocity = Vector2.Zero;
            }
            position += velocity;
        }
    }
}
