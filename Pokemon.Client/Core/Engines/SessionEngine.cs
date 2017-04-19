namespace Pokemon.Client.Core.Engines
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.GameObjects.Units.PlayableCharacters;
    using Models;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    //Info shared between screens
    public static class SessionEngine
    {
        public const int WindowHeight = 860;
        public const int WindowWidth = 1180;
        private static Trainer currentTrainer;
        public static SpriteFont PokemonFont;

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
        }

        public static void InitializeTrainer()
        {
            var model = new TrainerModel()
            {
                Name = "Pesho"
            };

            SessionEngine.currentTrainer = new Trainer(model);
        }

        public static void Update(GameTime gameTime)
        {

        }

    }
}
