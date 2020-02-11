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
        Texture2D man;
        Texture2D texture;
        Texture2D badman;
        Texture2D win;
        Texture2D lose;
        Rectangle manRect;
        Rectangle badmanRect;
        Rectangle finishRect;
        Texture2D finish;
        Random ran;
        bool won;
        bool lost;
        SoundEffect bounceSFX;
        SoundEffect winSFX;
        SoundEffect hitSFX;

        public Game2()
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
            ran = new Random();
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
            
            spriteFont = Content.Load<SpriteFont>("defaultFont");
            
            winSFX = Content.Load<SoundEffect>("winner");
            bounceSFX = Content.Load<SoundEffect>("bounce");
            hitSFX = Content.Load<SoundEffect>("hit");

            man = Content.Load<Texture2D>("man2");
            texture = Content.Load<Texture2D>("pixel");
            finish = Content.Load<Texture2D>("finish");
            badman = Content.Load<Texture2D>("badman");
            win = Content.Load<Texture2D>("win");
            lose = Content.Load<Texture2D>("lose");
            manRect.X = 50;
            manRect.Y = 400;
            manRect.Width = 75;
            manRect.Height = 75;

            if (!won)
            {
                badmanRect.X = 800;
                badmanRect.Y = ran.Next(400, 535);
                badmanRect.Width = 55;
                badmanRect.Height = 55;
            }
            finishRect = new Rectangle(925, 400, 100, 200);
            won = false;
            lost = false;
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
                manRect.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                manRect.Y += 5;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                manRect.X -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                manRect.X += 5;
            }
            
    
            //top
            if (manRect.Y < 345)
            {
                manRect.Y = 345;
            }

            if (manRect.Y > 600 - manRect.Height)
            {
                manRect.Y = 600 - manRect.Height;
            }

 


            if (manRect.X < 0)
            {

                manRect.X = 0;
            }

            if (manRect.X > GraphicsDevice.Viewport.Width - manRect.Width)
            {
                manRect.X = GraphicsDevice.Viewport.Width - manRect.Width;
            }

            if(!won) badmanRect.X -= 5;

            if (badmanRect.X < 0)
            {   bounceSFX.Play();
                badmanRect.X = 825;
                
                badmanRect.Y = ran.Next(400, 535);
            }

            if (manRect.Intersects(badmanRect))
            {
                hitSFX.Play();
                lost = true;
                badmanRect.X = 825;
                badmanRect.X -= 5;
                manRect.X = 50;
            }

            if (manRect.Intersects(finishRect))
            {
                winSFX.Play();
                won = true;
                badmanRect.X = 825;
                badmanRect.X -= 5;
                manRect.X = 50;
            }
            //if(manRect.Intersects())
            // TODO: Add your update logic here

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

            spriteBatch.Draw(man, manRect, Color.White);

            if (!won && !lost)
            {
                spriteBatch.Draw(badman, badmanRect, Color.White);
            }
            spriteBatch.Draw(texture, new Rectangle(0, 0, 1042, 345), Color.Black);
            spriteBatch.Draw(texture, new Rectangle(0, 600, 1042, 175), Color.Black);
            spriteBatch.Draw(finish, finishRect, Color.Yellow);

            if (won && !lost)
            {
                
                spriteBatch.DrawString(spriteFont, "YOU WIN WOO HOO!!!!!!", new Vector2(325, 450), Color.Purple);
            }
            if (lost && !won)
            {
                
                spriteBatch.DrawString(spriteFont, "YOU LOSE BOO HOO!!!!!!", new Vector2(325, 450), Color.Red);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
