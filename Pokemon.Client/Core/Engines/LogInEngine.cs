﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pokemon.Client.Textures;
using Pokemon.Client.UI_Elements;
using Pokemon.Client.UI_Elements.InputForms;

namespace Pokemon.Client.Core.Engines
{
    class LogInEngine
    {
        private static List<InputForm> forms = new List<InputForm>();

        public static List<InputForm> Forms
        {
            get { return LogInEngine.forms; }
            set { forms = value; }
        }

        public static void GenerateForms ( ContentManager contentManager )
        {
            forms = new List<InputForm>();

            //Username FORM
            Text usernameText = new Text
            {
                Color = Color.Black,
                Message = "Username:",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/PokemonFont_25")
            };
            InputForm usernameForm = new InputForm
            {
                SpriteSheet = TextureLoader.TextBoxSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                DescriptionOfField = usernameText,
                TextString = "",
                textFont = contentManager.Load<SpriteFont>("Fonts/PokemonFont_20"),
                isSecured = false
            };

            forms.Add (usernameForm);

            //Password FORM
            Text passwordText = new Text
            {
                Color = Color.Black,
                Message = "Password:",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/PokemonFont_25")
            };
            InputForm passwForm = new InputForm
            {
                SpriteSheet = TextureLoader.TextBoxSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                DescriptionOfField = passwordText,
                TextString = "",
                textFont = contentManager.Load<SpriteFont> ("Fonts/PokemonFont_20"),
                isSecured = true
            };

            forms.Add (passwForm);
        }
    }
}
