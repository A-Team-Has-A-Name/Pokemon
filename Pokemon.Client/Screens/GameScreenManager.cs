namespace Pokemon.Client.Screens
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;
    using System.Collections.Generic;

    public class GameScreenManager : IGameScreenManager
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ContentManager content;
        private Action onGameExit;

        private readonly List<IGameScreen> gameScreens;
        public GameScreenManager(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            gameScreens = new List<IGameScreen>();
        }

        public bool IsPaused { get; }

        public void ChangeScreen(IGameScreen screen)
        {
            RemoveAllScreens();

            gameScreens.Add(screen);

            screen.Initialize(content);
        }

        public void PushScreen(IGameScreen screen)
        {
            if (!IsScreenListEmpty())
            {
                var currentScreen = GetCurretScreen();

                currentScreen.Pause();
            }

            gameScreens.Add(screen);

            screen.Initialize(content);
        }

        private bool IsScreenListEmpty()
        {
            return this.gameScreens.Count <= 0; 
        }

        private IGameScreen GetCurretScreen()
        {
            return gameScreens[gameScreens.Count - 1];
        }

        private void RemoveAllScreens()
        {
            while (!IsScreenListEmpty())
            {
                RemoveCurrentScreen();
            }
        }

        private void RemoveCurrentScreen()
        {
            var screen = GetCurretScreen();

            screen.Dispose();

            gameScreens.Remove(screen);
        }

        public void PopScreen()
        {
            if (!IsScreenListEmpty())
            {
                RemoveCurrentScreen();
            }

            if (!IsScreenListEmpty())
            {
                var screen = GetCurretScreen();

                screen.Resume();
            }
        }

        public void ChangeBetweenScreens()
        {
            if (!IsScreenListEmpty())
            {
                var screen = GetCurretScreen();

                if (!screen.IsPaused)
                {
                    screen.ChangeBetweenScreens();
                }
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            if (!IsScreenListEmpty())
            {
                var screen = GetCurretScreen();

                if (!screen.IsPaused)
                {
                    screen.HandleInput(gameTime);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!IsScreenListEmpty())
            {
                var screen = GetCurretScreen();

                if (!screen.IsPaused)
                {
                    screen.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!IsScreenListEmpty())
            {
                var screen = GetCurretScreen();

                if (!screen.IsPaused)
                {
                    screen.Draw(gameTime, spriteBatch);
                }
            }
        }

        public void Exit()
        {
            if(onGameExit != null)
            {
                onGameExit();
            }
        }

        public event Action OnGameExit
        {
            add { onGameExit += value; }
            remove { onGameExit -= value; }
        }

        public void Dispose()
        {
            RemoveAllScreens();
        }

        public void Init(ContentManager content)
        {
           
        }

        public void Pause()
        {
           
        }


        public void Resume()
        {
            
        }
    }
}
