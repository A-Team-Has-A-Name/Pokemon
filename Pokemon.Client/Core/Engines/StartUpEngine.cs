
using System;
using System.Runtime.CompilerServices;

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


    public static class StartUpEngine
    {
        private static List<Button> buttons = new List<Button>();

        public static List<Button> Buttons
        {
            get
            {
                return StartUpEngine.buttons;
            }
        }

        public static void GenerateButtons(ContentManager contentManager)
        {
            buttons = new List<Button>();
            Text LogInText = new Text
            {
                Color = Color.Black,
                Message = "Log In",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial_20")
            };

            //Log in
            Button LogInButton = new Button
            {
                SpriteSheet = TextureLoader.ButtonSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                Text = LogInText,
                DefaultTextColour = Color.Black,
                HoverTextColour = Color.White
            };

            buttons.Add(LogInButton);

            //Register

            Text RegisterText = new Text
            {
                Color = Color.Black,
                Message = "Register",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial_20")
            };

            Button RegisterButton = new Button
            {
                SpriteSheet = TextureLoader.ButtonSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                Text = RegisterText,
                DefaultTextColour = Color.Black,
                HoverTextColour = Color.White
            };

            buttons.Add (RegisterButton);

            //Exit

            Text ExitText = new Text
            {
                Color = Color.Black,
                Message = "Exit",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial_20")
            };

            Button ExitButton = new Button
            {
                SpriteSheet = TextureLoader.ButtonSheet,
                DefaultSpriteColour = Color.White,
                HoverSpriteColour = Color.Orange,
                Text = ExitText,
                DefaultTextColour = Color.Black,
                HoverTextColour = Color.White
            };

            ExitButton.OnClicked += Exit;
            
            buttons.Add (ExitButton);


           


        }

        public static void Exit()
        {
            System.Environment.Exit(0);
        }

        
    }
}
