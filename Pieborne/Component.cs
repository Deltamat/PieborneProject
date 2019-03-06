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
    public abstract class Component
    {
        GameObject gameObject;
        AnimatedGameObject animatedGameObject;

        public GameObject GetGameObject
        {
            get
            {
                return gameObject;
            }
        }

        public AnimatedGameObject GetAnimatedGameObject
        {
            get
            {
                return animatedGameObject;
            }
        }

        public virtual void Attach(GameObject gameObject)
        {
            this.gameObject = gameObject;
            if (gameObject is AnimatedGameObject)
            {
                animatedGameObject = (AnimatedGameObject)gameObject;
            }
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
