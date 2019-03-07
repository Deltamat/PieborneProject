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
        public EnemyBoss(float speed, Vector2 startPos) : base(speed, startPos)
        {
            this.speed = speed;
            Health = 100;
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
