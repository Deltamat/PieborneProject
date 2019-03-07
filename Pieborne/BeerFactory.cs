using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class BeerFactory : Factory
    {
        static BeerFactory instance;
        public static BeerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BeerFactory();
                }
                return instance;
            }
        }

        private BeerFactory()
        {

        }

        public override GameObject Create(string type, Vector2 startPos)
        {
            GameObject gameObject = new GameObject();

            switch (type)
            {
                case "Beer":
                    gameObject.AddComponent(new SpriteRenderer("beer"));
                    gameObject.AddComponent(new Beer());
                    break;

                case "Key Lime Pie":
                    gameObject.AddComponent(new SpriteRenderer("keylimepie"));
                    gameObject.AddComponent(new Beer());
                    break;
            }

            gameObject.Transform.Position = startPos;
            return gameObject;
        }
    }
}
