
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.Screens;
using Pokemon.Client.Textures;
using Pokemon.Data;
using Pokemon.Models;
using PokemonDB.Data.Store;

namespace Pokemon.Client.UI_Elements.InputForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    enum FormType
    {
        LogIn,
        Register,
        ChooseTrainer
    }

    class InputFormManager
    {
        public InputFormManager ( )
        {
            this.forms = new List<InputForm> ( );
        }

        public double ErrorDuration { get; set; }

        public SpriteFont spriteFont { get; set; }

        public bool errorIsDisplayed { get; set; }

        public bool isHidden { get; set; }

        public int ErrorElapsedTime { get; set; }

        public string ErrorMessage { get; set; }

        private Vector2 baseInputFormFramePosition { get; set; }

        private KeyboardState currentKeyboardState;

        private KeyboardState oldKeyboardState;

        public int currentlyHoveredForm { get; set; }

        private Action<GameScreenManager> onExecution;

        public void LogInExecution ( GameScreenManager screenManager )
        {

            bool LogInSuccessful = false;

            string username = this.forms[0].TextString;
            string password = forms[1].TextString;


            UserModel UM = UserStore.GetUserByLoginData (username, password);
            if ( UM != null )
            {
                LogInSuccessful = true;
            }
           

            if ( LogInSuccessful )
            {
                SessionEngine.User = new User.User (UM);
                UserStore.UpdateUser (UM.Username);
                screenManager.ChangeScreen (new ChooseTrainerScreen (screenManager));
            }
            else
            {
                ErrorMessage = "Login data is incorrect!";
                errorIsDisplayed = true;
            }
        }

        public void RegisterExecution ( GameScreenManager screenManager )
        {
            bool RegisterSuccessful = false;

            string username = this.forms[0].TextString;
            string password = forms[1].TextString;
            string email = forms[2].TextString;


            UserModel UM = UserStore.RegisterUser (username, password, email);
            if ( UM != null )
            {
                RegisterSuccessful = true;
            }

            if ( RegisterSuccessful )
            {
                SessionEngine.User = new User.User (UM);
                UserStore.UpdateUser (UM.Username);
                screenManager.ChangeScreen (new ChooseTrainerScreen (screenManager));
            }
            else
            {
                ErrorMessage = "Username already exists!";
                errorIsDisplayed = true;
            }
        }

        public bool trainedWasCreated { get; set; }


        public void CreateTrainer ( GameScreenManager screenManager )
        {
            trainedWasCreated = false;

            string name = this.forms[0].TextString;

            if ( name.Length < 3 )
            {
                ErrorMessage = "Name is too short!";
                errorIsDisplayed = true;
                return;
            }

            if ( SessionEngine.User.Trainers.Select (tr => tr.Name).Contains (name) )
            {
                ErrorMessage = "You already have a trainer with this name!";
                errorIsDisplayed = true;
                return;
            }

            int id = SessionEngine.User.Id;

            TrainerStore.RegisterTrainer (name, id);

            trainedWasCreated = true;

            SessionEngine.User = new User.User (UserStore.GetUserById (SessionEngine.User.Id));


        }

        internal event Action<GameScreenManager> OnExecution
        {
            add { onExecution += value; }
            remove { onExecution -= value; }
        }

        public void InitializeForms ( ContentManager contentManager, FormType type )
        {
            forms = new List<InputForm> ( );
            trainedWasCreated = false;

            oldKeyboardState = currentKeyboardState = Keyboard.GetState ( );

            currentlyHoveredForm = 0;
            switch ( type )
            {
                case FormType.LogIn:
                    LogInEngine.GenerateForms (contentManager);
                    forms = LogInEngine.Forms;

                    break;
                case FormType.Register:
                    RegisterEngine.GenerateForms (contentManager);
                    forms = RegisterEngine.Forms;
                    break;
                case FormType.ChooseTrainer:
                    ChooseTrainerEngine.GenerateForms (contentManager);
                    forms = ChooseTrainerEngine.Forms;
                    break;
            }



            for ( int i = 0; i < forms.Count; i++ )
            {
                if ( currentlyHoveredForm == i )
                {
                    this.forms[i].isHovered = true;
                }
                Vector2 currentFormPosition = new Vector2 (0, i * ( TextureLoader.TextBoxHeigthScaled + 50 ));
                this.forms[i].Position = baseInputFormFramePosition + currentFormPosition;
            }

        }

        public void setFramePosition ( float X, float Y )
        {
            float baseInputFormFrameXPosition = ( SessionEngine.WindowWidth - TextureLoader.TextBoxWidthScaled ) / X;
            float baseInputFormFrameYPosition = ( SessionEngine.WindowHeight - TextureLoader.TextBoxHeigthScaled * ( this.forms.Count + 1 ) ) / ( int ) Y;
            baseInputFormFramePosition = new Vector2 (baseInputFormFrameXPosition, baseInputFormFrameYPosition);
        }

        public void setFramePosition ( int X, int Y )
        {
            baseInputFormFramePosition = new Vector2 (X, Y);
        }

        public void ErrorMassageLogic ( GameTime gameTime )
        {
            this.ErrorElapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if ( ErrorElapsedTime > ErrorDuration )
            {
                errorIsDisplayed = false;
                ErrorElapsedTime = 0;
            }
            else if ( errorIsDisplayed )
            {
                errorIsDisplayed = true;

            }
        }


        private List<InputForm> forms { get; set; }

        public void Update ( GameTime gameTime )
        {
            ErrorMassageLogic (gameTime);

            foreach ( var form in this.forms )
            {
                form.Update (gameTime);
            }

            for ( int i = 0; i < forms.Count; i++ )
            {
                if ( currentlyHoveredForm == i )
                {
                    forms[i].isHovered = true;
                }
                else
                {
                    forms[i].isHovered = false;
                }
            }

        }

        public void Draw ( SpriteBatch spriteBatch )
        {
            if ( !isHidden )
            {
                foreach ( var form in this.forms )
                {
                    form.Draw (spriteBatch);
                }

                if ( errorIsDisplayed )
                {
                    int ErrorBoxPositionX = 30;
                    int ErrorBoxPositionY = 30;

                    spriteBatch.Draw (TextureLoader.TheOnePixel, new Rectangle (ErrorBoxPositionX, ErrorBoxPositionY, SessionEngine.WindowWidth - 200, 40), new Rectangle (0, 0, 1, 1), Color.Red);
                    Vector2 textPosition = new Vector2 (ErrorBoxPositionX, ErrorBoxPositionY) + new Vector2 (10, 8);
                    spriteBatch.DrawString (spriteFont, ErrorMessage, textPosition, Color.Black);
                }
            }


        }

        public void HandleInput ( GameTime gameTime, GameScreenManager screenManager )
        {
            if ( !isHidden )
            {
                oldKeyboardState = currentKeyboardState;
                currentKeyboardState = Keyboard.GetState ( );

                if ( currentKeyboardState.IsKeyDown (Keys.Enter) && oldKeyboardState.IsKeyUp (Keys.Enter) )
                {
                    foreach (var inputForm in forms)
                    {
                        if (inputForm.TextString.Length < 3)
                        {
                            errorIsDisplayed = true;
                            ErrorMessage = "Input is too short!";
                            return;
                        }
                    }
                    onExecution (screenManager);
                }
                else if ( currentKeyboardState.IsKeyDown (Keys.Tab) && oldKeyboardState.IsKeyUp (Keys.Tab) )
                {
                    if ( currentlyHoveredForm < forms.Count - 1 )
                    {
                        //Go one form down
                        currentlyHoveredForm++;
                    }
                    else
                    {
                        //Was on last place comes to the top
                        currentlyHoveredForm = 0;
                    }
                }
            }

            for ( int i = 0; i < forms.Count; i++ )
            {
                if ( currentlyHoveredForm == i )
                {
                    forms[i].HandleInput (gameTime);
                }
            }
        }

    }

}

