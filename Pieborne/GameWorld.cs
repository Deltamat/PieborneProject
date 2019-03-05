﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        Texture2D Background;
        List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> gameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> gameObjectsToRemove = new List<GameObject>();
        public static float deltaTime;        
        Texture2D collisionTexture;
        SpriteFont font;
        GameObject g;
        GameObject e;
        
        Texture2D heart;
        public static AnimatedGameObject ago;

        static GameWorld instance;
        static public GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Creates a rectangle whithin the bounds of the window
        /// </summary>
        public Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
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
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            Background = Content.Load<Texture2D>("BrickyBackground");
            font = Content.Load<SpriteFont>("font");
            heart = Content.Load<Texture2D>("heart");
            GameObject reee = new GameObject();
            //ago = new AnimatedGameObject(10, 10);
            gameObjectsToRemove.Add(reee);

            Song song = Content.Load<Song>("Attack of  the Flaming Pie Tins");
            MediaPlayer.Play(song);

            g = new AnimatedGameObject(10,10);
            g.AddComponent(new SpriteRenderer("cat_fighter_sprite"));
            g.AddComponent(new Collider());
            //g.AddComponent(new AnimatedGameObject(10, 10, g));
            g.AddComponent(new Player(300, new Vector2(700)));
            g.AddComponent(new Gravity());
            g.LoadContent(Content);

            for (int i = 0; i < 30; i++)
            {
                
            }
            e = new GameObject();
            e.Transform.Position = new Vector2(800, 600);
            e.AddComponent(new Collider());
            e.AddComponent(new Terrain());
            e.AddComponent(new SpriteRenderer("beer"));
            e.AddComponent(new Beer());

            for (int i = 0; i < 100; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i - 1, 1064));
            }
            for (int i = 0; i < 67; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(8, 16 * i + 8));
            }

            GameObject singleBlock = new GameObject();
            singleBlock.Transform.Position = new Vector2(784, 800);
            singleBlock.AddComponent(new Collider());
            singleBlock.AddComponent(new SpriteRenderer("bricks/Brick Black"));
            singleBlock.AddComponent(new Terrain());
            singleBlock.LoadContent(Content);

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
                    if (otherItem != item && otherItem.CollisionBox.Intersects(item.CollisionBox) && otherItem.GetComponent("Terrain") == null)
                    {
                        Collider temp = (Collider)otherItem.GetComponent("Collider");
                        temp.Collision(item);
                    }
                    else if (item.GetComponent("Gravity") != null)
                    {
                        Gravity tmp = (Gravity)item.GetComponent("Gravity");
                        tmp.IsFalling = true;
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
            spriteBatch.Begin();
            spriteBatch.Draw(Background, ScreenSize, Color.White);
            foreach (GameObject item in gameObjects)
            {
                item.Draw(spriteBatch);
                #if DEBUG
                DrawCollisionBox(item);
                #endif
            }
            for (int i = 0; i < Player.Instance.Health; i++)
            {
                spriteBatch.Draw(heart, new Vector2(35 * i + 5, 5), Color.White);
            }

            Gravity tmp = (Gravity)g.GetComponent("Gravity");
            spriteBatch.DrawString(font, $"{tmp.IsFalling}", new Vector2(600), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
