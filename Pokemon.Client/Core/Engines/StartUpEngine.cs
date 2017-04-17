
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
        private static List<IUpdatable> updatableObjects = new List<IUpdatable> ( );
        private static List<Interfaces.IDrawable> drawableObjects = new List<IDrawable> ( );

        private static List<Button> buttons = new List<Button>();

        public static List<Button> Buttons
        {
            get
            {
                return StartUpEngine.buttons;
            }
        }

        public static List<Interfaces.IDrawable> DrawableObjects
        {
            get
            {
                return StartUpEngine.drawableObjects;
            }
        }

        public static List<IUpdatable> UpdatableObjects
        {
            get
            {
                return StartUpEngine.updatableObjects;
            }
        }

        public static void GenerateButtons(ContentManager contentManager)
        {
            Text LogInText = new Text
            {
                Color = Color.Black,
                Message = "Log In",
                SpriteFont = contentManager.Load<SpriteFont> ("Fonts/Arial")
            };

            //Log in
            Button LogInButton = new Button
            {
                SpriteSheet = TextureLoader.ButtonSheet,
                DefaultSpriteColour = Color.Blue,
                HoverSpriteColour = Color.Red,
                Text = LogInText,
                DefaultTextColour = Color.Black,
                HoverTextColour = Color.White
            };

            buttons.Add(LogInButton);

        }

        public static void InitializeUpdatableObjects ( ContentManager contentManager )
        {
            foreach (var button in buttons)
            {
                updatableObjects.Add (button);
            }
            
            //Register
            //Exit
        }

        public static void InitializeDrawableObjects ( ContentManager contentManager )
        {
            foreach (var button  in buttons)
            {
                    drawableObjects.Add (button);
            }
            
            //Register
            //Exit 
        }
    }
}
