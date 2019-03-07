using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class EnemyFactory : Factory
    {
        static EnemyFactory instance;
        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        }

        private EnemyFactory()
        {

        }

        public override GameObject Create(string type, Vector2 startPos)
        {
            GameObject gameObject = new GameObject();

            switch(type)
            {
                case "Rat":
                    gameObject.AddComponent(new SpriteRenderer("RatMelee"));
                    gameObject.AddComponent(new EnemyMelee(50, startPos));
                    gameObject.AddComponent(new Collider());
                    gameObject.AddComponent(new Gravity());
                    break;

                case "RangedRat":
                    gameObject.AddComponent(new SpriteRenderer("RatRanged"));
                    gameObject.AddComponent(new EnemyRanged(200, startPos));
                    gameObject.AddComponent(new Collider());
                    gameObject.AddComponent(new Gravity());
                    break;

                case "BossRat":
                    gameObject.AddComponent(new SpriteRenderer("RatQueen"));
                    gameObject.AddComponent(new EnemyBoss(200, startPos));
                    gameObject.AddComponent(new Collider());
                    break;
            }

            gameObject.Transform.Position = startPos;
            return gameObject;
        }
    }
}
