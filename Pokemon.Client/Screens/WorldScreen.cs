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
    using Textures;
    using UI_Elements.Windows;
    using UI_Elements.Windows.Message;
    using GameObjects.Units.NonPlayableCharacters;
    using UI_Elements.Notifications;
    using UI_Elements;

    public class WorldScreen : IGameScreen
    {
        private bool exitGame;

        private readonly GameScreenManager screenManager;
        public WindowManager windowManager;
        public NotificationManager notificationManager;
        public bool IsPaused { get; private set; }

        public WorldScreen(GameScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Initialize(ContentManager content)
        {
            WorldEngine.ResetWorld();
            WorldEngine.PopulateWildPokemon();
            WorldEngine.InitializeDrawableObjects();
            WorldEngine.InitializeUpdatableObjects();
            windowManager = WorldEngine.WindowManager;
            notificationManager = WorldEngine.NotificationManager;
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
            for (int i = 0; i < WorldEngine.WildPokemon.Count; i++)
            {
                var currentPokemon = WorldEngine.WildPokemon[i];
                if (Collision.CheckForCollisionBetweenCollidables(SessionEngine.Trainer, currentPokemon))
                {
                    WorldEngine.PendingPokemonToRemove = currentPokemon;

                    currentPokemon.IsEncountered = true;
                    SessionEngine.Trainer.IsSurprised = true;
                    bool pokemonIsCaught = Pokemon.IsCaught();
                    Messages.EncounteredPokemonMessageWindow((int)SessionEngine.Trainer.Y, currentPokemon.Name, pokemonIsCaught);
                    if (pokemonIsCaught)
                    {
                        SessionEngine.Trainer.CatchPokemon(currentPokemon);
                    }
                }
            }

            foreach (IUpdatable u in WorldEngine.UpdatableObjects)
            {
                u.Update(gameTime);
            }

            windowManager.Update(gameTime);
            notificationManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(WorldEngine.background, new Vector2(0, 0), new Rectangle(0, 0, SessionEngine.WindowWidth, SessionEngine.WindowHeight), Color.White);

            foreach (Interfaces.IDrawable d in WorldEngine.DrawableObjects)
            {
                d.Draw(spriteBatch);                
            }

            //Draw remaining pokemon in world
            spriteBatch.Draw(TextureLoader.TheOnePixel, new Rectangle(1085, 30, 55, 55), Color.DarkGreen);
            int x = 1090;
            if(WorldEngine.WildPokemon.Count < 10)
            {
                x = 1100;
            }
            spriteBatch.DrawString(SessionEngine.PokemonFont, "" + WorldEngine.WildPokemon.Count, new Vector2(x, 35), Color.White);

            windowManager?.Draw(spriteBatch);
            notificationManager?.Draw(spriteBatch);
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                screenManager.PopScreen();
            }
            else if (keyboard.IsKeyDown(Keys.M))
            {
                Messages.DisplayCaughtPokemonMessageWindow();
            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                SessionEngine.SaveGame();
                notificationManager.QueueNotification(new Notification("Saved.", SessionEngine.PokemonFont, Color.White));
            }           
        }

        //Windows
 
        public void Dispose()
        {

        }
    }
}
