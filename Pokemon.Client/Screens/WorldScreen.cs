using Pokemon.Client.Core.Engines;

namespace Pokemon.Client.Screens
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;
    using Microsoft.Xna.Framework.Input;
    using Core;
    using Content;
    using Core.Engines;

    public class WorldScreen : IGameScreen
    {
        private bool exitGame;

        private readonly GameScreenManager screenManager;
        public bool IsPaused { get; private set; }

        public WorldScreen(GameScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Initialize(ContentManager content)
        {
            WorldEngine.PopulateWildPokemon();
            WorldEngine.InitializeDrawableObjects();
            WorldEngine.InitializeUpdatableObjects();
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
            foreach (var p in WorldEngine.WildPokemon)
            {
                if (Collision.CheckForCollisionBetweenCollidables(SessionEngine.Trainer, p))
                {
                    p.IsEncountered = true;
                }
            }

            foreach (IUpdatable u in WorldEngine.UpdatableObjects)
            {
                u.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Interfaces.IDrawable d in WorldEngine.DrawableObjects)
            {
                d.Draw(spriteBatch);
            }

        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                exitGame = true;
            }

            //removing current screen test
            //if (keyboard.IsKeyDown(Keys.B))
            //{
            //    screenManager.PopScreen();
            //}
        }

        public void Dispose()
        {
           
        }
    }
}
