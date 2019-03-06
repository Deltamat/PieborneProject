using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    abstract public class Enemy : Component
    {
        protected IState currentState;
        public float speed;
        public Vector2 currentDirection;
        protected Vector2 startPos;
        public Vector2 directionLeft;
        public Vector2 directionRight;
        protected int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        

        public Enemy(float speed, Vector2 startPos)
        {
            this.startPos = startPos;
            this.speed = speed;
            directionLeft = new Vector2(-1, 0);
            directionRight = new Vector2(1, 0);
        }

        public void Move(Vector2 direction)
        {
            
        }

        public void ChangeState(IState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter(this);
        }
        
        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            GetGameObject.Transform.Position = startPos;
        }

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           
        }
    }
}
