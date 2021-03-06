﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pieborne
{
    class EnemyMelee : Enemy
    {
        public EnemyMelee(float speed, Vector2 startPos) : base(speed, startPos)
        {
            this.speed = speed;
            Health = 10;
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
