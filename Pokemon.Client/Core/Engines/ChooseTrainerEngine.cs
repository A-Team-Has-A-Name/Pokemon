
using System;
using System.Runtime.CompilerServices;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;

namespace Pokemon.Client.Core.Engines
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;
    using Pokemon.Client.Textures;
    using Pokemon.Client.UI_Elements;
    using IDrawable = Pokemon.Client.Interfaces.IDrawable;

    using System.Collections.Generic;


    public static class ChooseTrainerEngine
    {
        private static List<Trainer> trainers = new List<Trainer> ( );

        public static List<Trainer> Trainers
        {
            get
            {
                return ChooseTrainerEngine.trainers;
            }
        }

        public static void GenerateTrainers ( ContentManager contentManager )
        {
            User.User User = SessionEngine.User;
            //TODO Get trainer from user

        }

        public static void Exit ( )
        {
            System.Environment.Exit (0);
        }


    }
}
