using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Client.Interfaces;

namespace Pokemon.Client.Screens
{
    class RegisterScreen : IGameScreen
    {
        private readonly GameScreenManager screenManager;

        public bool IsPaused { get; }

        public void Pause ( )
        {

        }

        public void Resume ( )
        {

        }

        public void Initialize ( ContentManager content )
        {

        }

        public void Update ( GameTime gameTime )
        {

        }

        public void Draw ( GameTime gameTime, SpriteBatch spriteBatch )
        {

        }

        public void HandleInput ( GameTime gameTime )
        {

        }

        public void Dispose ( )
        {

        }

        public RegisterScreen ( GameScreenManager screenManager )
        {
            this.screenManager = screenManager;
        }
    }
}
