namespace Pokemon.Client.Screens
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class WorldScreen : IGameScreen
    {
        private bool exitGame;
        private readonly GameScreenManager screenManager;
        public bool IsPaused { get; private set; }

        public WorldScreen(GameScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Init(ContentManager content)
        {

        }

        public void ChangeBetweenScreens()
        {
            if (exitGame)
            {
                screenManager.Exit();
            }
        }
    
        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                exitGame = true;
            }
        }

        public void Dispose()
        {
           
        }
    }
}
