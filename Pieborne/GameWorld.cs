﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pieborne
{
    //killroy was here

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> gameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> gameObjectsToRemove = new List<GameObject>();
        public static float deltaTime;
        public static Vector2 ScreenSize;
        GameObject g;
        GameObject e;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            ScreenSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            g = new GameObject();
            g.AddComponent(new SpriteRenderer("test"));
            g.AddComponent(new Collider());
            g.AddComponent(new Player(300, Vector2.Zero));
            g.LoadContent(Content);

            e = new GameObject();
            e.Transform.Position = new Vector2(ScreenSize.X * 0.5f, 300);
            e.AddComponent(new Collider());
            e.AddComponent(new SpriteRenderer("test"));
            e.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (GameObject item in gameObjects)
            {
                item.Update(gameTime);

                foreach (GameObject otherItem in gameObjects)
                {
                    if (otherItem != item && otherItem.CollisionBox.Intersects(item.CollisionBox))
                    {
                        Collider temp = (Collider)otherItem.GetComponent("Collider");
                        temp.Collision(item);
                    }
                }
            }

            foreach (GameObject item in gameObjectsToAdd)
            {
                gameObjects.Add(item);
            }
            gameObjectsToAdd.Clear();

            foreach (GameObject item in gameObjectsToRemove)
            {
                gameObjects.Remove(item);
            }
            gameObjectsToRemove.Clear();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront, null);
            foreach (GameObject item in gameObjects)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
