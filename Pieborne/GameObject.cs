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
    public class GameObject
    {
        public List<Component> components = new List<Component>();
        Transform transform;
        public Transform Transform
        {
            get
            {
                return transform;
            }
        }

        public virtual Rectangle CollisionBox
        {
            get
            {
                SpriteRenderer sr = (SpriteRenderer)GetComponent("SpriteRenderer");
                return new Rectangle((int)(transform.Position.X - sr.sprite.Width * 0.5), (int)(transform.Position.Y - sr.sprite.Height * 0.5), sr.sprite.Width, sr.sprite.Height);
            }
        }

        public GameObject()
        {
            transform = new Transform(this, Vector2.Zero);
            AddComponent(transform);
            if (GameWorld.gameObjectsToAdd.Contains(this) is false)
            {
                GameWorld.gameObjectsToAdd.Add(this);
            }
        }

        public void AddComponent(Component component)
        {
            component.Attach(this);
            components.Add(component);
        }

        public Component GetComponent(string component)
        {
            return null;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Component item in components)
            {
                item.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component item in components)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component item in components)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
