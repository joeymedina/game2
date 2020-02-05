using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D man;
        Texture2D texture;
        Rectangle manRect;
        int manSpeedUpDown = 0;
        int manSpeedLeftRight = 0;
        Texture2D finish;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

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
            man = Content.Load<Texture2D>("man2");
            texture = Content.Load<Texture2D>("pixel");
            finish = Content.Load<Texture2D>("finish");
            manRect.X = 50;
            manRect.Y = 400;
            manRect.Width = 75;
            manRect.Height = 75;

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


            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                manSpeedUpDown -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                manSpeedUpDown += 1;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                manSpeedLeftRight -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                manSpeedLeftRight += 1;
            }
            
manRect.Y += manSpeedUpDown;
            manRect.X += manSpeedLeftRight;

            
            if (manRect.Y < 0)
            {
                manRect.Y = 0;
            }
            if (manRect.Y > GraphicsDevice.Viewport.Height - manRect.Height)
            {
                manRect.Y = GraphicsDevice.Viewport.Height - manRect.Height;
            }

            if (manRect.X < 0)
            {
                manRect.X = 0;
            }

            if (manRect.X > GraphicsDevice.Viewport.Width - manRect.Width)
            {
                manRect.X = GraphicsDevice.Viewport.Width - manRect.Width;
            }
            
            // TODO: Add your update logic here

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
            spriteBatch.Draw(man, manRect, Color.White);
            spriteBatch.Draw(texture, new Rectangle(0, 600, 1042, 10), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(925, 400, 100, 200), Color.Yellow);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
