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
                    currentPokemon.IsEncountered = true;
                    SessionEngine.Trainer.IsSurprised = true;
                    bool pokemonIsCaught = Pokemon.IsCaught();
                    EncounteredPokemonMessageWindow((int)SessionEngine.Trainer.Y, currentPokemon.Name, pokemonIsCaught);

                    if (pokemonIsCaught)
                    {
                        SessionEngine.Trainer.CatchPokemon(currentPokemon);
                        //TODO: Change font Size
                        //var notification = new Notification($"Added {currentPokemon.Name} to Pokemon Storage.",
                                                          //  SessionEngine.PokemonFont,
                                                          //  Color.White);

                        //notificationManager.QueueNotification(notification);
                    }

                    WorldEngine.WildPokemon.Remove(currentPokemon);
                    WorldEngine.UpdatableObjects.Remove(currentPokemon);
                    WorldEngine.DrawableObjects.Remove(currentPokemon);
                    //notificationManager.QueueNotification(new Notification($"Added {currentPokemon.Name} to Pokemon Storage.",
                                                        //    SessionEngine.PokemonFont,
                                                        //    Color.White));
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

            windowManager?.Draw(spriteBatch);
            notificationManager?.Draw(spriteBatch);
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.screenManager.PopScreen();
                exitGame = true;
            }

            if (keyboard.IsKeyDown(Keys.B))
            {
                screenManager.PopScreen();
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                SessionEngine.SaveGame();
                notificationManager.QueueNotification(new Notification("Saved.", SessionEngine.PokemonFont, Color.White));
            }           
        }

        //Windows
        public void EncounteredPokemonMessageWindow(int trainerY, string pokemonName, bool isCaught)
        {
            int y = getWindowY(trainerY);
            var messageWindow = new MessageWindow(new Vector2(15, y), 1150, 200);
            messageWindow.AddPage($"Encountered a wild {pokemonName}!", false);
            messageWindow.AddPage("Attempting to catch ", true);

            if (isCaught)
            {
                messageWindow.AddPage($"Successfully caught {pokemonName}.", false);
            }
            else
            {
                messageWindow.AddPage("The pokemon ran away.", false);
            }

            windowManager.QueueWindow(messageWindow);           
        }

        private int getWindowY(int trainerY)
        {
            int yWindow = 650;

            if (trainerY > SessionEngine.WindowHeight / 2)
            {
                yWindow = 15;
            }
            return yWindow;
        }

        public void Dispose()
        {

        }
    }
}
