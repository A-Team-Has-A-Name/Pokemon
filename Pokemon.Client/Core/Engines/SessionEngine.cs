namespace Pokemon.Client.Core.Engines
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.GameObjects.Units.PlayableCharacters;
    using Pokemon.Client.GameObjects.Units.NonPlayableCharacters;
    using Models;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using System.Collections.Generic;
    using PokemonDB.Data.Store;

    //Info shared between screens, rename to MainEngine?
    public static class SessionEngine
    {
        public const int WindowHeight = 860;
        public const int WindowWidth = 1180;
        private static Trainer currentTrainer;
        public static SpriteFont PokemonFont;

        public static User.User User { get; set; }

        public static void Load(ContentManager content)
        {
            PokemonFont = content.Load<SpriteFont>("Fonts/PokemonFont");

        }

        public static Trainer Trainer
        {
            get
            {
                return SessionEngine.currentTrainer;
            }
            set { currentTrainer = value; }
        }

        public static void InitializeTrainer()
        {
           // SessionEngine.currentTrainer = new Trainer(TrainerStore.GetTrainerById(2));
            var debug = SessionEngine.currentTrainer;
        }

        public static void Update(GameTime gameTime)
        {

        }

        public static void SaveGame()
        {
            PokemonStore.UpdatePokemon(SessionEngine.Trainer.GetCaughtPokemonModelsForUpdate());
            TrainerStore.UpdateTrainer(SessionEngine.Trainer.GetCurrentModelState());
        }

    }
}
