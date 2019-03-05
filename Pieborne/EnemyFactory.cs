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
                    break;

                case "RangedRat":
                    break;
            }

            gameObject.Transform.Position = startPos;
            return gameObject;
        }
    }
}
