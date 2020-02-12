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
    public class Enemy
    {
       public Rectangle enemyRect;

        Game2 game;

        Texture2D badman;

        SoundEffect bounceSFX;

        public Random ran;
        public Enemy(Game2 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            ran = new Random();
            if (!game.won)
            {
                enemyRect.X = 920;

                enemyRect.Y = ran.Next(400, 535);
                enemyRect.Width = 55;
                enemyRect.Height = 55;
            }

            //if (game.won || game.lost)
            //{
            //    enemyRect.X = 825;
            //    enemyRect.Y = 400;
            //}
        }

        /// <summary>
        /// Loads content
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {

            
            badman = content.Load<Texture2D>("badman");
            bounceSFX = content.Load<SoundEffect>("bounce");
        }

        /// <summary>
        /// Updates 
        /// </summary>
        /// <param name="gameTime">The game's GameTime</param>
        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
            if (!game.won && !game.lost) enemyRect.X -= 5;
           

            if (enemyRect.X < 0)
            {
                bounceSFX.Play();
                enemyRect.X = 920;

                enemyRect.Y = ran.Next(400, 535);
            }



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if (!game.won && !game.lost)
            //{}
            if(enemyRect.X < 915)
            {
             spriteBatch.Draw(badman, enemyRect, Color.White);
            }

            
        }
    }

}

