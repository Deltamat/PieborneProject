﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieborne
{
    public class InputHandler
    {
        private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();

        static InputHandler instance;
        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        private InputHandler()
        {
            keybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
            keybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
            keybinds.Add(Keys.W, new JumpCommand());

            keybinds.Add(Keys.Space, new JumpCommand());

            keybinds.Add(Keys.Right, new ShootCommand(new Vector2(1, 0)));
            keybinds.Add(Keys.Left, new ShootCommand(new Vector2(-1, 0)));
            keybinds.Add(Keys.Up, new ShootCommand(new Vector2(0, -1)));
            keybinds.Add(Keys.Down, new ShootCommand(new Vector2(0, 1)));

        }

        public void Execute(Player p)
        {
            KeyboardState keystate = Keyboard.GetState();

            foreach (Keys key in keybinds.Keys)
            {
                if (keystate.IsKeyDown(key))
                {
                    keybinds[key].Execute(p);
                }
            }
        }
    }
}
