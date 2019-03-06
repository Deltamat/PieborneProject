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
        public SpriteRenderer sr;
        Collider collider;
        Player player;
        Terrain terrain;
        Gravity gravity;
        Beer beer;
        Projectile projectile;
        public string type;

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
                return new Rectangle((int)(transform.Position.X - sr.sprite.Width * 0.5), (int)(transform.Position.Y - sr.sprite.Height * 0.5), sr.sprite.Width, sr.sprite.Height);
            }
        }

        public void IsColliding(GameObject otherObject)
        {

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

            if (component is SpriteRenderer)
            {
                sr = (SpriteRenderer)component;
            }
            else if (component is Collider)
            {
                collider = (Collider)component;
            }
            else if (component is Player)
            {
                player = (Player)component;
                type = "Player";
            }
            else if (component is Terrain)
            {
                terrain = (Terrain)component;
                type = "Terrain";
            }
            else if (component is Gravity)
            {
                gravity = (Gravity)component;
            }
            else if (component is Beer)
            {
                beer = (Beer)component;
                type = "Beer";
            }
            else if (component is Projectile)
            {
                projectile = (Projectile)component;
                type = "Projectile";
            }

        }

        public Component GetComponent(string component)
        {
            switch (component)
            {
                case "SpriteRenderer":
                    return sr;

                case "Collider":
                    return collider;

                case "Player":
                    return player;

                case "Terrain":
                    return terrain;

                case "Gravity":
                    return gravity;

                case "Beer":
                    return beer;

                case "Projectile":
                    return projectile;
            }
            return null;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Component item in components)
            {
                item.LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Component item in components)
            {
                item.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component item in components)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
