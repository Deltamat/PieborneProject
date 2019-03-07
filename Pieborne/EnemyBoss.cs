using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pieborne
{
    public class EnemyBoss : Enemy
    {
        public override int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health <= 0)
                {
                    GameWorld.gameObjectsToRemove.Add(GetGameObject);
                    BeerFactory.Instance.Create("Key Lime Pie", GetGameObject.Transform.Position); //Spawn key lime pie
                }
            }
        }

        public EnemyBoss(float speed, Vector2 startPos) : base(speed, startPos)
        {
            this.speed = speed;
            Health = 100;
            ChangeState(new PatrolState());
        }


        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
