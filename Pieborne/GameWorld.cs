using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Pieborne
{
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
        public double shootTimer;
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
            #if !DEBUG
            graphics.IsFullScreen = true;
            #endif
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
            GenerateWorld();

            EnemyFactory.Instance.Create("Rat", new Vector2(632, 900));
            EnemyFactory.Instance.Create("Rat", new Vector2(700, 500));
            EnemyFactory.Instance.Create("Rat", new Vector2(800, 100));
            EnemyFactory.Instance.Create("RangedRat", new Vector2(632, 700));
            EnemyFactory.Instance.Create("RangedRat", new Vector2(632, 800));
            EnemyFactory.Instance.Create("RangedRat", new Vector2(680, 360));
            EnemyFactory.Instance.Create("BossRat", new Vector2(1500, 850));

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

            Song song = Content.Load<Song>("Attack of  the Flaming Pie Tins");
            MediaPlayer.Play(song);

            PlayerFactory.Instance.Create("Player", new Vector2(100, 950));

            BeerFactory.Instance.Create("Beer", new Vector2(100, 700)); //1st
            BeerFactory.Instance.Create("Beer", new Vector2(634, 810)); //2nd
            BeerFactory.Instance.Create("Beer", new Vector2(1100, 700)); //3rd
            BeerFactory.Instance.Create("Beer", new Vector2(680, 330)); //4th       
            BeerFactory.Instance.Create("Beer", new Vector2(100, 400)); //5th
            BeerFactory.Instance.Create("Beer", new Vector2(548, 238)); //6th
            BeerFactory.Instance.Create("Beer", new Vector2(1510, 450)); //7th
        }

        private void GenerateWorld()
        {
            TerrainFactory.Instance.Create("Brick", new Vector2(872, 536)); //right pyramid
            TerrainFactory.Instance.Create("Brick", new Vector2(488, 536)); //left pyramid
            TerrainFactory.Instance.Create("Brick64", new Vector2(1128, 216)); //blocker before boss
            TerrainFactory.Instance.Create("Brick64", new Vector2(1740, 750)); //boss platform
            TerrainFactory.Instance.Create("Brick64", new Vector2(1300, 750)); //boss platform
            TerrainFactory.Instance.Create("Brick64", new Vector2(1510, 500)); //boss platform
            for (int i = 0; i < 2; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 872, 552)); //right pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 472, 552)); //left pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(i * 64 + 648, 408)); //cage
            }
            for (int i = 0; i < 3; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(i * 16 + 1104, 752)); //step platform right
                TerrainFactory.Instance.Create("Brick", new Vector2(i * 16 + 72, 488)); //step platform left
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 872, 568)); //right pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 456, 568)); //left pyramid
                TerrainFactory.Instance.Create("Brick32", new Vector2(200, 32 * i + 167)); //top zigzag
                TerrainFactory.Instance.Create("Brick32", new Vector2(360, 32 * i + 81)); //top zigzag
                TerrainFactory.Instance.Create("Brick32", new Vector2(520, 32 * i + 167)); //top zigzag
                TerrainFactory.Instance.Create("Brick32", new Vector2(680, 32 * i + 81)); //top zigzag
            }
            for (int i = 0; i < 4; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 872, 584)); //right pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 440, 584)); //left pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(632, i * 16 + 320)); //cage
                TerrainFactory.Instance.Create("Brick", new Vector2(728, i * 16 + 320)); //cage

            }
            for (int i = 0; i < 5; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(i * 16 + 600, 750)); //ranged rat platform bottom
                TerrainFactory.Instance.Create("Brick", new Vector2(i * 16 + 600, 850)); //ranged rat platform bottom
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 872, 600)); //right pyramid
                TerrainFactory.Instance.Create("Brick", new Vector2(16 * i + 424, 600)); //left pyramid
            }            
            for (int i = 0; i < 14; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(150, i * 16 + 744)); //starting wall
            }
            for (int i = 0; i < 64; i++)
            {
                TerrainFactory.Instance.Create("Brick", new Vector2(1152, i * 16 + 256)); //left boss wall
            }
            for (int i = 0; i < 16; i++)
            {
                TerrainFactory.Instance.Create("Brick64", new Vector2(64 * i + 64, 640)); //middle layer roof
                TerrainFactory.Instance.Create("Brick64", new Vector2(64 * i + 152, 280)); //bottom layer roof
                TerrainFactory.Instance.Create("Brick128", new Vector2(128 * i, 1024)); //border
                TerrainFactory.Instance.Create("Brick128", new Vector2(128 * i, 0)); //border
            }
            for (int i = 0; i < 9; i++)
            {
                TerrainFactory.Instance.Create("Brick128", new Vector2(0, 128 * i)); //border
                TerrainFactory.Instance.Create("Brick128", new Vector2(1920, 128 * i)); //border
            }
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
            if (shootTimer < Player.Instance.shootingSpeed)
            {
                shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            foreach (GameObject item in gameObjects)
            {
                item.Update(gameTime);

                foreach (GameObject otherItem in gameObjects)
                {
                    if (otherItem != item && otherItem.CollisionBox.Intersects(item.CollisionBox) && otherItem.type != "Terrain" && otherItem.type != "Beer")
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
