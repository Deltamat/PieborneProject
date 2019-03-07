using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    class BossState : IState
    {
        private Vector2 direction;
        private Enemy parent;
        double reloadTimer;
        double bossTimer;
        Vector2 top;
        Vector2 bot;
        Vector2 left;
        Vector2 right;
        int shots;



        public void Enter(Enemy parent)
        {
            this.parent = parent;
            ResetVectors();
        }

        public void Execute()
        {
            reloadTimer += GameWorld.deltaTime;
            bossTimer += GameWorld.deltaTime;

            direction = Player.position - parent.GetGameObject.Transform.Position;
            direction.Normalize();

            if (bossTimer < 10) // skyd efter spilleren
            {
                if (reloadTimer > 1f)
                {
                    if (shots == 4) // shotgun skud
                    {
                        direction = Player.position - parent.GetGameObject.Transform.Position;
                        direction.Normalize();
                        ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);
                        direction = Player.position + new Vector2(20, 20) - parent.GetGameObject.Transform.Position;
                        direction.Normalize();
                        ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);
                        direction = Player.position + new Vector2(-20, -20) - parent.GetGameObject.Transform.Position;
                        direction.Normalize();
                        ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);
                        direction = Player.position + new Vector2(20, -20) - parent.GetGameObject.Transform.Position;
                        direction.Normalize();
                        ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);

                        shots = 0;
                    }
                    else
                    {
                        ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + direction * 60, direction);
                        reloadTimer = 0;
                        shots++;
                    }

                }
            }

            if (bossTimer > 10) // spin med skudene
            {
                top += new Vector2(3, 3);
                Vector2 topDirection = (top - parent.GetGameObject.Transform.Position);
                topDirection.Normalize();

                bot += new Vector2(-3, -3);
                Vector2 botDirection = (bot - parent.GetGameObject.Transform.Position);
                botDirection.Normalize();

                left += new Vector2(3, -3);
                Vector2 leftDirection = (left - parent.GetGameObject.Transform.Position);
                leftDirection.Normalize();

                right += new Vector2(-3, 3);
                Vector2 rightDirection = (right - parent.GetGameObject.Transform.Position);
                rightDirection.Normalize();

                if (reloadTimer > 0.1f)
                {
                    ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + topDirection * 60, topDirection);
                    ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + botDirection * 60, botDirection);
                    ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + leftDirection * 60, leftDirection);
                    ProjectileFactory.Instance.Create("Stjerne", parent.GetGameObject.Transform.Position + rightDirection * 60, rightDirection);
                    reloadTimer = 0;
                }
            }
            if (bossTimer > 12)
            {
                bossTimer = 0;
                ResetVectors();
            }
            
        }

        public void Exit()
        {
            
        }

        private void ResetVectors()
        {
            top = new Vector2(parent.GetGameObject.Transform.Position.X, parent.GetGameObject.Transform.Position.Y - 300);
            bot = new Vector2(parent.GetGameObject.Transform.Position.X, parent.GetGameObject.Transform.Position.Y + 300);
            left = new Vector2(parent.GetGameObject.Transform.Position.X - 300, parent.GetGameObject.Transform.Position.Y);
            right = new Vector2(parent.GetGameObject.Transform.Position.X + 300, parent.GetGameObject.Transform.Position.Y);
        }
    }
}
