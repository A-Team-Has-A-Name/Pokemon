using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Content;
using Pokemon.Client.Core;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;
using Pokemon.Client.Interfaces;
using Pokemon.Client.Textures;
using Pokemon.Client.UI_Elements;
using Pokemon.Client.UI_Elements.InputForms;
using Pokemon.Client.UI_Elements.Windows;
using Pokemon.Models;
using PokemonDB.Data.Store;
using ButtonState = Pokemon.Client.UI_Elements.ButtonState;

namespace Pokemon.Client.Screens
{
    struct TrainerPackage
    {
        public Trainer trainer { get; set; }
        public Button button { get; set; }
    }

    public class ChooseTrainerScreen : IGameScreen
    {
        private KeyboardState currentKeyboardState;

        private KeyboardState oldKeyboardState;

        private readonly GameScreenManager screenManager;

        public Window window;
        public WindowManager windowManager;

        private int CurrentlyHoveredTrainerPackage { get; set; }

        private bool exitGame;

        private List<Text> Texts;

        private List<TrainerPackage> TrainerPackages;

        private InputFormManager nameInputFormManager { get; set; }

        public bool IsPaused { get; private set; }

        private ContentManager contentManager { get; set; }



        public ChooseTrainerScreen ( GameScreenManager screenManager )
        {
            this.screenManager = screenManager;
        }

        public void Pause ( )
        {
            this.IsPaused = true;
        }

        public void Resume ( )
        {
            this.IsPaused = false;
        }

        public void ChangeToLogInScreen ( )
        {
            screenManager.ChangeBetweenScreens (new LogInScreen (screenManager));
        }

        public void ChangeToRegisterScreen ( )
        {
            screenManager.ChangeBetweenScreens (new RegisterScreen (screenManager));
        }

        public void ChangeToWorldScreen ( )
        {
            screenManager.ChangeBetweenScreens (new WorldScreen (screenManager));
        }

        public void ShowNameCreationForm ( )
        {
            nameInputFormManager.isHidden = false;
        }

        public void LogOut ( )
        {
            SessionEngine.User = new User.User (new UserModel ( ));
            screenManager.PopScreen ( );
            screenManager.PushScreen (new StartUpScreen (screenManager));

        }

        public void RefreshData ( ContentManager content )
        {

            //Generate the buttons
            CurrentlyHoveredTrainerPackage = 0;
            ChooseTrainerEngine.GenerateTrainers (content);
            ChooseTrainerEngine.GenerateButtons (content); ;

            TrainerPackages = new List<TrainerPackage> ( );

            //connect buttons and trainers
            TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[0], trainer = new Trainer (new TrainerModel ( )) });
            for ( int i = 0; i < ChooseTrainerEngine.Trainers.Count; i++ )
            {
                TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[i + 1], trainer = ChooseTrainerEngine.Trainers[i] });
            }
            //create button doesnt have a trainer
            TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[ChooseTrainerEngine.Buttons.Count - 1], trainer = new Trainer (new TrainerModel ( )) });

            //Center buttons
            float baseTrainerPackageFrameXPosition = ( SessionEngine.WindowWidth - TextureLoader.ButtonTextureWidth ) / 5;
            float baseTrainerPackageFrameYPosition = ( SessionEngine.WindowHeight - TextureLoader.ButtonTextureHeight * ( this.TrainerPackages.Count ) ) / 2;
            Vector2 baseTrainerPackageFramePosition = new Vector2 (baseTrainerPackageFrameXPosition, baseTrainerPackageFrameYPosition);

            //Attach the functions to the buttons
            TrainerPackages[0].button.OnClicked += LogOut;
            for ( int i = 1; i < TrainerPackages.Count - 1; i++ )
            {
                TrainerPackages[i].button.OnClicked += ChangeToWorldScreen;
            }
            TrainerPackages[TrainerPackages.Count - 1].button.OnClicked += ShowNameCreationForm; ;

            //Initiallize first button to be hovered and set positions 
            for ( int i = 0; i < this.TrainerPackages.Count; i++ )
            {
                if ( this.CurrentlyHoveredTrainerPackage == i )
                {
                    this.TrainerPackages[i].button.currentButtonState = ButtonState.Hovered;
                }

                Vector2 currentTrainerPackagePosition = new Vector2 (0, i * TextureLoader.ButtonTextureHeight);
                this.TrainerPackages[i].button.Position = baseTrainerPackageFramePosition + currentTrainerPackagePosition;
            }

            nameInputFormManager.InitializeForms (content, FormType.ChooseTrainer);

        }

        public void Initialize ( ContentManager content )
        {
            currentKeyboardState = oldKeyboardState = Keyboard.GetState ( );

            this.contentManager = content;
            //Generate the buttons
            CurrentlyHoveredTrainerPackage = 0;
            ChooseTrainerEngine.GenerateTrainers (content);
            ChooseTrainerEngine.GenerateButtons (content);

            TrainerPackages = new List<TrainerPackage> ( );
            //connect buttons and trainers

            TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[0], trainer = new Trainer (new TrainerModel ( )) });
            for ( int i = 0; i < ChooseTrainerEngine.Trainers.Count; i++ )
            {
                TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[i + 1], trainer = ChooseTrainerEngine.Trainers[i] });
            }
            //create button doesnt have a trainer
            TrainerPackages.Add (new TrainerPackage { button = ChooseTrainerEngine.Buttons[ChooseTrainerEngine.Buttons.Count - 1], trainer = new Trainer (new TrainerModel ( )) });

            //Center buttons
            float baseTrainerPackageFrameXPosition = ( SessionEngine.WindowWidth - TextureLoader.ButtonTextureWidth ) / 5;
            float baseTrainerPackageFrameYPosition = ( SessionEngine.WindowHeight - TextureLoader.ButtonTextureHeight * ( this.TrainerPackages.Count ) ) / 2;
            Vector2 baseTrainerPackageFramePosition = new Vector2 (baseTrainerPackageFrameXPosition, baseTrainerPackageFrameYPosition);

            //Attach the functions to the buttons
            TrainerPackages[0].button.OnClicked += LogOut;
            for ( int i = 1; i < TrainerPackages.Count - 1; i++ )
            {
                TrainerPackages[i].button.OnClicked += ChangeToWorldScreen;
            }
            TrainerPackages[TrainerPackages.Count - 1].button.OnClicked += ShowNameCreationForm;


            //Initiallize first button to be hovered and set positions 
            for ( int i = 0; i < this.TrainerPackages.Count; i++ )
            {
                if ( this.CurrentlyHoveredTrainerPackage == i )
                {
                    this.TrainerPackages[i].button.currentButtonState = ButtonState.Hovered;
                }

                Vector2 currentTrainerPackagePosition = new Vector2 (0, i * TextureLoader.ButtonTextureHeight);
                this.TrainerPackages[i].button.Position = baseTrainerPackageFramePosition + currentTrainerPackagePosition;
            }
            // Is writing


            this.nameInputFormManager = new InputFormManager ( );

            int NameInputFrameXPosition = SessionEngine.WindowWidth - 350;
            int NameInputFrameYPosition = SessionEngine.WindowHeight - 100;
            nameInputFormManager.setFramePosition (NameInputFrameXPosition, NameInputFrameYPosition);

            nameInputFormManager.ErrorDuration = 5000;
            nameInputFormManager.isHidden = true;
            nameInputFormManager.OnExecution += nameInputFormManager.CreateTrainer;
            nameInputFormManager.ErrorMessage = "You already have a trainer with this name!";
            nameInputFormManager.spriteFont = content.Load<SpriteFont> ("Fonts/PokemonFont_15");
            nameInputFormManager.InitializeForms (content, FormType.ChooseTrainer);

            nameInputFormManager.currentlyHoveredForm = CurrentlyHoveredTrainerPackage - TrainerPackages.Count - 1;

        }

        public void Update ( GameTime gameTime )
        {

            foreach ( var TrainerPackage in this.TrainerPackages )
            {
                TrainerPackage.button.Update (gameTime);
            }

            if ( this.nameInputFormManager.trainedWasCreated )
            {

                this.RefreshData (contentManager);
                nameInputFormManager.trainedWasCreated = false;
            }
            nameInputFormManager.Update (gameTime);
        }

        public void Draw ( GameTime gameTime, SpriteBatch spriteBatch )
        {


            //spriteBatch.Draw(TextureLoader.MenuBackgorund, Vector2.Zero, new Rectangle(0, 0, SessionEngine.WindowWidth, SessionEngine.WindowHeight), Color.White);

            spriteBatch.Draw (TextureLoader.StartUpBackground, new Rectangle (0, 0, SessionEngine.WindowWidth, SessionEngine.WindowHeight), new Rectangle (0, 0, 1920, 1080), Color.White);
            nameInputFormManager.Draw (spriteBatch);
            foreach ( var TrainerPackage in this.TrainerPackages )
            {
                TrainerPackage.button.Draw (spriteBatch);
            }
        }

        public void HandleInput ( GameTime gameTime )
        {

            nameInputFormManager.currentlyHoveredForm = CurrentlyHoveredTrainerPackage - TrainerPackages.Count + 1;



            nameInputFormManager.HandleInput (gameTime, screenManager);

            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState ( );

            //Handle UP/Down browsing of the buttons

            if ( currentKeyboardState.IsKeyDown (Keys.Up) && oldKeyboardState.IsKeyUp (Keys.Up) )
            {
                if ( this.CurrentlyHoveredTrainerPackage > 0 )
                {
                    CurrentlyHoveredTrainerPackage--;
                }
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.Down) && oldKeyboardState.IsKeyUp (Keys.Down) )
            {
                if ( this.CurrentlyHoveredTrainerPackage < this.TrainerPackages.Count - 1 )
                {
                    CurrentlyHoveredTrainerPackage++;
                }
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.D) && oldKeyboardState.IsKeyUp (Keys.D) )
            {
                if ( CurrentlyHoveredTrainerPackage != 0 && CurrentlyHoveredTrainerPackage != TrainerPackages.Count - 1 )
                {
                    int trainerToRemoveId = TrainerPackages[CurrentlyHoveredTrainerPackage].trainer.Id;
                    TrainerStore.DeleteTrainer(trainerToRemoveId);
                    RefreshData(contentManager);
                }
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.Enter) && oldKeyboardState.IsKeyUp (Keys.Enter) )
            {
                for ( int i = 0; i < this.TrainerPackages.Count; i++ )
                {
                    if ( this.CurrentlyHoveredTrainerPackage == i )
                    {
                        this.TrainerPackages[i].button.currentButtonState = ButtonState.Clicked;
                        SessionEngine.Trainer = TrainerPackages[i].trainer;
                    }
                }
            }

            //Decide which button is being hovered
            for ( int i = 0; i < this.TrainerPackages.Count; i++ )
            {

                if ( this.CurrentlyHoveredTrainerPackage == i && this.TrainerPackages[i].button.currentButtonState != ButtonState.Clicked )
                {
                    this.TrainerPackages[i].button.currentButtonState = ButtonState.Hovered;
                }
                else if ( this.TrainerPackages[i].button.currentButtonState == ButtonState.Hovered )
                {
                    this.TrainerPackages[i].button.currentButtonState = ButtonState.None;
                }
            }
        }

        public void Dispose ( )
        {

        }
    }
}
