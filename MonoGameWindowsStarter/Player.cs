using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWindowsStarter
{
    public class Player
    {

        Game2 game;

        public SoundEffect hitSFX;

        public SoundEffect winSFX;

        Rectangle manRect;

        Texture2D man;


        public Player(Game2 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            manRect.X = 50;
            manRect.Y = 400;
            manRect.Width = 75;
            manRect.Height = 75;
        }

        /// <summary>
        /// Loads content
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {
            man = content.Load<Texture2D>("man2");
            winSFX = content.Load<SoundEffect>("winner");
            hitSFX = content.Load<SoundEffect>("hit");
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="gameTime">The game's GameTime</param>
        public void Update(GameTime gameTime, Enemy enemy)
        {

            var keyboardState = Keyboard.GetState();
            var badmanRect = enemy.enemyRect;
            /*movement*/
            // move up down left right
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

            /*bounds*/
            // keeps man between the two black bars
            if (manRect.Y < 345)
            {
                manRect.Y = 345;
            }

            if (manRect.Y > 600 - manRect.Height)
            {
                manRect.Y = 600 - manRect.Height;
            }

            //keeps man on screen sides
            if (manRect.X < 0)
            {
                manRect.X = 0;
            }

            if (manRect.X > game.GraphicsDevice.Viewport.Width - manRect.Width)
            {
                manRect.X = game.GraphicsDevice.Viewport.Width - manRect.Width;
            }

            if (manRect.Intersects(enemy.enemyRect))
            {
                hitSFX.Play();
                game.lost = true;
                game.won = false;
                enemy.enemyRect.X = 920;
                enemy.enemyRect.Y = enemy.ran.Next(400, 535);
                badmanRect.X -= 5;
                manRect.X = 50;
            }

            if (manRect.Intersects(game.finishRect))
            {
                winSFX.Play();
                game.won = true;
                game.lost = false;
                enemy.enemyRect.X = 920;
                enemy.enemyRect.Y = enemy.ran.Next(400, 535);
                //badmanRect.X = 825;
                //badmanRect.X -= 5;
                manRect.X = 50;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(man, manRect, Color.White);
        }
    }
}
