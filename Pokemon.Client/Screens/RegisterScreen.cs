using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.Interfaces;
using Pokemon.Client.Textures;

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
            spriteBatch.Draw (TextureLoader.MenuBackgorund, Vector2.Zero, new Rectangle (0, 0, SessionEngine.WindowWidth,SessionEngine.WindowHeight), Color.White);
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
