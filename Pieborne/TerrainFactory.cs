using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class TerrainFactory : Factory
    {
        static TerrainFactory instance;
        static public TerrainFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TerrainFactory();
                }
                return instance;
            }
        }

        private TerrainFactory()
        {

        }

        public override GameObject Create(string type, Vector2 startPos)
        {
            GameObject gameObject = new GameObject();

            switch(type)
            {
                case "Brick":
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new SpriteRenderer("bricks/Brick Black"));
                    //gameObject.AddComponent(new Collider());
                    break;
                case "Brick32":
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new SpriteRenderer("bricks/Brick Black 32"));
                    break;
                case "Brick64":
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new SpriteRenderer("bricks/Brick Black 64"));
                    break;
                case "Brick128":
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new SpriteRenderer("bricks/Brick Black 128"));
                    break;
            }
            gameObject.Transform.Position = startPos;
            return gameObject;
        }
    }
}
