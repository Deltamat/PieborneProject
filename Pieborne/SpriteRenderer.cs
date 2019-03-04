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
    class SpriteRenderer : Component
    {
        public Texture2D sprite;
        string spriteName;

        public SpriteRenderer(string spriteName)
        {
            this.spriteName = spriteName;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, this.GetGameObject().Transform.Position, null, Color.White, 0f, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 1f);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>($"{spriteName}");
        }

        public SpriteRenderer Clone()
        {
            return (SpriteRenderer)this.MemberwiseClone();
        }
    }
}
