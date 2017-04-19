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
using Pokemon.Client.UI_Elements.InputForms;

namespace Pokemon.Client.Screens
{
    class RegisterScreen : IGameScreen
    {
        private InputFormManager inputManager { get; set; }

        private readonly GameScreenManager screenManager;

        public bool IsPaused { get; private set; }

        public void Pause ( )
        {
            this.IsPaused = true;
        }

        public void Resume ( )
        {
            this.IsPaused = false;
        }

        public void Initialize ( ContentManager content )
        {
            inputManager = new InputFormManager ( );
            inputManager.ErrorDuration = 5000;
            inputManager.OnExecution += inputManager.RegisterExecution;
            inputManager.ErrorMessage = "Username already exists";
            inputManager.spriteFont = content.Load<SpriteFont> ("Fonts/PokemonFont_15");
            inputManager.InitializeForms (content, FormType.Register);
        }

        public void Update ( GameTime gameTime )
        {
            inputManager.Update (gameTime);
        }

        public void Draw ( GameTime gameTime, SpriteBatch spriteBatch )
        {
            spriteBatch.Draw (TextureLoader.MenuBackgorund, Vector2.Zero, new Rectangle (0, 0, SessionEngine.WindowWidth, SessionEngine.WindowHeight), Color.White);
            inputManager.Draw(spriteBatch);
        }

        public void HandleInput ( GameTime gameTime )
        {
            inputManager.HandleInput (gameTime, screenManager);
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
