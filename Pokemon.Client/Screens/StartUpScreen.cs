
namespace Pokemon.Client.Screens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Pokemon.Client.Core.Engines;
    using Pokemon.Client.Interfaces;
    using Pokemon.Client.Textures;
    using Pokemon.Client.UI_Elements;
    using ButtonState = Pokemon.Client.UI_Elements.ButtonState;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUpScreen : IGameScreen
    {
        private KeyboardState currentKeyboardState;

        private KeyboardState oldKeyboardState;

        private readonly GameScreenManager screenManager;

        private int CurrentlyHoveredButton { get; set; }

        private bool exitGame;

        private List<Text> Texts;

        private List<Button> Buttons;

        public bool IsPaused { get; private set; }

        public StartUpScreen(GameScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        public void Pause()
        {
            this.IsPaused = true;
        }

        public void Resume()
        {
            this.IsPaused = false;
        }

        public void ChangeToLogInScreen()
        {
            screenManager.ChangeBetweenScreens(new LogInScreen(screenManager));
        }

        public void ChangeToRegisterScreen()
        {
            screenManager.ChangeBetweenScreens(new RegisterScreen(screenManager));
        }

        public void ChangeToWorldScreen()
        {
            screenManager.ChangeBetweenScreens(new WorldScreen(screenManager));
        }
        public void Initialize(ContentManager content)
        {
            currentKeyboardState = oldKeyboardState = Keyboard.GetState();

            //Generate the buttons
            CurrentlyHoveredButton = 0;
            StartUpEngine.GenerateButtons(content);
            this.Buttons = StartUpEngine.Buttons;

            //Center buttons
            float baseButtonFrameXPosition = (SessionEngine.WindowWidth - TextureLoader.ButtonTextureWidth) / 5;
            float baseButtonFrameYPosition = (SessionEngine.WindowHeight - TextureLoader.ButtonTextureHeight * (this.Buttons.Count + 1)) / 2;
            Vector2 baseButtonFramePosition = new Vector2(baseButtonFrameXPosition, baseButtonFrameYPosition);

            //Attach the functions to the buttons
            Buttons.Where(b => b.Text.Message == "Log In").FirstOrDefault().OnClicked += ChangeToLogInScreen;
            Buttons.Where(b => b.Text.Message == "Register").FirstOrDefault().OnClicked += ChangeToRegisterScreen;

            //Initiallize first button to be hovered
            for (int i = 0; i < this.Buttons.Count; i++)
            {
                if (this.CurrentlyHoveredButton == i)
                {
                    this.Buttons[i].currentButtonState = ButtonState.Hovered;
                }
                Vector2 currentButtonPosition = new Vector2(0, i * TextureLoader.ButtonTextureHeight);
                this.Buttons[i].Position = baseButtonFramePosition + currentButtonPosition;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var button in this.Buttons)
            {
                button.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(TextureLoader.MenuBackgorund, Vector2.Zero, new Rectangle(0, 0, SessionEngine.WindowWidth, SessionEngine.WindowHeight), Color.White);

            spriteBatch.Draw (TextureLoader.StartUpBackground,new Rectangle(0,0,SessionEngine.WindowWidth,SessionEngine.WindowHeight), new Rectangle (0,0, 1920,1080), Color.White);
            foreach (var button in this.Buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            /*For debugging purposes - quick access to WorldScreen
            if ( KS.IsKeyDown (Keys.W) )
            {
                screenManager.ChangeBetweenScreens (new WorldScreen (screenManager));
            }
            */


            //Handle UP/Down browsing of the buttons

            if (currentKeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                if (this.CurrentlyHoveredButton > 0)
                {
                    CurrentlyHoveredButton--;
                }
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.Down) && oldKeyboardState.IsKeyUp (Keys.Down) )
            {
                if (this.CurrentlyHoveredButton < this.Buttons.Count - 1)
                {
                    CurrentlyHoveredButton++;
                }
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.Enter) && oldKeyboardState.IsKeyUp (Keys.Enter) )
            {
                for (int i = 0; i < this.Buttons.Count; i++)
                {
                    if (this.CurrentlyHoveredButton == i)
                    {
                        this.Buttons[i].currentButtonState = ButtonState.Clicked;
                    }
                }
            }

            //Decide which button is being hovered
            for (int i = 0; i < this.Buttons.Count; i++)
            {

                if (this.CurrentlyHoveredButton == i && this.Buttons[i].currentButtonState != ButtonState.Clicked)
                {
                    this.Buttons[i].currentButtonState = ButtonState.Hovered;
                }
                else if (this.Buttons[i].currentButtonState == ButtonState.Hovered)
                {
                    this.Buttons[i].currentButtonState = ButtonState.None;
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
