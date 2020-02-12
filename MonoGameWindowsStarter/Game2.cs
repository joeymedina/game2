using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D texture;

        Player player;
        Enemy enemy;

        Texture2D win;
        Texture2D lose;



        public Rectangle finishRect;
        Texture2D finish;

        public bool won;
        public bool lost;



        public Game2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player(this);
            enemy = new Enemy(this);
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

            /**Enemy Class**/
            //ran = new Random();

            graphics.ApplyChanges();
            player.Initialize();
            enemy.Initialize();

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
            won = false;
            lost = false;
            spriteFont = Content.Load<SpriteFont>("defaultFont");

            player.LoadContent(Content);


            enemy.LoadContent(Content);

            texture = Content.Load<Texture2D>("pixel");
            finish = Content.Load<Texture2D>("finish");

            win = Content.Load<Texture2D>("win");
            lose = Content.Load<Texture2D>("lose");


            finishRect = new Rectangle(925, 400, 100, 200);




        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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

            if (keyboardState.IsKeyDown(Keys.R))
            {
                won = false;
                lost = false;
            }
            player.Update(gameTime, enemy);
            enemy.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(texture, new Rectangle(0, 0, 1042, 345), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(0, 600, 1042, 175), Color.Black);
            spriteBatch.Draw(finish, finishRect, Color.Yellow);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            if (won && !lost)
            {

                spriteBatch.DrawString(spriteFont, "YOU WIN WOO HOO!!!!!! \n press R to restart", new Vector2(325, 450), Color.Purple);
            }
            if (lost && !won)
            {

                spriteBatch.DrawString(spriteFont, "YOU LOSE BOO HOO!!!!!! \n press R to restart", new Vector2(325, 450), Color.Red);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
