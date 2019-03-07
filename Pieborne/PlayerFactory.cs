using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class PlayerFactory : Factory
    {
        static PlayerFactory instance;
        public static PlayerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerFactory();
                }
                return instance;
            }
        }

        private PlayerFactory()
        {

        }

        public override GameObject Create(string type, Vector2 startPos)
        {
            AnimatedGameObject g = new AnimatedGameObject(10, 10);

            switch (type)
            {
                case "Player":

                    g.AddComponent(new SpriteRenderer("cat_fighter_sprite"));
                    g.AddComponent(new Collider());
                    g.AddComponent(Player.Instance);
                    g.AddComponent(new Gravity());
                    //g.LoadContent(Content);
                    break;
            }

            g.Transform.Position = startPos;
            return g;
        }

        
    }
}
