namespace Pokemon.Client.Core.Engines
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.GameObjects.Units.PlayableCharacters;
    using Models;

    //Info shared between screens
    public static class SessionEngine
    {
        public const int WindowHeight = 860;
        public const int WindowWidth = 1180;
        private static Trainer currentTrainer;
        
        //keep user data here maybe

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
