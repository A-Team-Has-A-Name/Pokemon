
using System;
using System.Runtime.CompilerServices;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;
using Pokemon.Client.UI_Elements.InputForms;

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

        private static List<Button> buttons = new List<Button> ( );

        public static List<Trainer> Trainers
        {
            get
            {
                return ChooseTrainerEngine.trainers;
            }
        }

        public static List<Button> Buttons
        {
            get
            {
                return ChooseTrainerEngine.buttons;
            }
        }

        private static List<InputForm> forms = new List<InputForm> ( );

        public static List<InputForm> Forms
        {
            get { return ChooseTrainerEngine.forms; }
            set { forms = value; }
        }

        public static void GenerateTrainers ( ContentManager contentManager )
        {
            User.User User = SessionEngine.User;

            trainers = User.Trainers;
            //TODO Get trainer from user

        }

        public static void GenerateButtons ( ContentManager contentManager )
        {
            int numberOfTrainers = SessionEngine.User.Trainers.Count;

            for ( int i = 0; i < numberOfTrainers; i++ )
            {
                Text Name = new Text
                {
                    Color = Color.Black,
                    Message = SessionEngine.User.Trainers[i].Name,
                    SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial_20")
                };

                //Log in
                Button button = new Button
                {
                    SpriteSheet = TextureLoader.ButtonSheet,
                    DefaultSpriteColour = Color.White,
                    HoverSpriteColour = Color.Orange,
                    Text = Name,
                    TrainerSheet = TextureLoader.TrainerSheet,
                    DefaultTextColour = Color.Black,
                    HoverTextColour = Color.White
                };

                buttons.Add (button);
            }

            Text CreateTrainer = new Text
            {
                Color = Color.Black,
                Message = "Create",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial_20")
            };

            //Log in
            Button createButton = new Button
            {
                SpriteSheet = TextureLoader.ButtonSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                Text = CreateTrainer,
                DefaultTextColour = Color.Black,
                HoverTextColour = Color.White
            };

            buttons.Add(createButton);

        }

        public static void GenerateForms ( ContentManager contentManager )
        {
            //Username FORM
            Text nameText = new Text
            {
                Color = Color.Black,
                Message = "Trainer Name:",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/PokemonFont_25")
            };
            InputForm nameForm = new InputForm
            {
                SpriteSheet = TextureLoader.TextBoxSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                DescriptionOfField = nameText,
                TextString = "",
                textFont = contentManager.Load<SpriteFont> ("Fonts/PokemonFont_20"),
                isSecured = false
            };

            forms.Add (nameForm);

            
        }
        public static void Exit ( )
        {
            System.Environment.Exit (0);
        }


    }
}
