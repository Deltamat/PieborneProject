using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pieborne
{
    class ProjectileFactory : Factory
    {
        static ProjectileFactory instance;
        public static ProjectileFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectileFactory();
                }
                return instance;
            }
        }

        private ProjectileFactory()
        {

        }

        public GameObject Create(string type, Vector2 startPos, Vector2 direction)
        {
            GameObject gameObject = new GameObject();

            switch (type)
            {
                case "Kunai":
                    gameObject.AddComponent(new SpriteRenderer("Kunai_Pixel"));
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new Projectile(direction, 300));
                    gameObject.AddComponent(new Collider());
                    break;

                case "Stjerne":
                    gameObject.AddComponent(new SpriteRenderer("Ninja_Star_Pixel"));
                    gameObject.AddComponent(new Terrain());
                    gameObject.AddComponent(new Projectile(direction, 300));
                    gameObject.AddComponent(new Collider());
                    break;
            }

            gameObject.Transform.Position = startPos;
            return gameObject;
        }

        public override GameObject Create(string type, Vector2 startPos)
        {
            throw new NotImplementedException();
        }
    }
}
