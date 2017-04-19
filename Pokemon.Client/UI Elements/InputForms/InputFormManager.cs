
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.Screens;
using Pokemon.Client.Textures;

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
        Register
    }

    class InputFormManager
    {
        public InputFormManager ( )
        {
            this.forms = new List<InputForm> ( );
        }

        private KeyboardState currentKeyboardState;

        private KeyboardState oldKeyboardState;

        private int currentlyHoveredForm { get; set; }

        private Action onExecution;

        internal event Action OnExecution
        {
            add { onExecution += value; }
            remove { onExecution -= value; }
        }
        public void InitializeForms ( ContentManager contentManager, FormType type )
        {
            oldKeyboardState = currentKeyboardState = Keyboard.GetState();

            currentlyHoveredForm = 0;
            switch ( type )
            {
                case FormType.LogIn:
                    LogInEngine.GenerateForms (contentManager);
                    forms = LogInEngine.Forms;

                    break;
                case FormType.Register:
                    //TODO

                    break;
            }

            float baseInputFormFrameXPosition = ( SessionEngine.WindowWidth - TextureLoader.TextBoxWidthScaled ) / 2;
            float baseInputFormFrameYPosition = ( SessionEngine.WindowHeight - TextureLoader.TextBoxHeigthScaled * ( this.forms.Count + 1 ) ) / 2;
            Vector2 baseInputFormFramePosition = new Vector2 (baseInputFormFrameXPosition, baseInputFormFrameYPosition);

            Vector2 baseInputFormsFramePosition = new Vector2 (200);
            for ( int i = 0; i < forms.Count; i++ )
            {
                if ( currentlyHoveredForm == i )
                {
                    this.forms[i].isHovered = true;
                }
                Vector2 currentFormPosition = new Vector2 (0, i * (TextureLoader.TextBoxHeigthScaled + 50));
                this.forms[i].Position = baseInputFormsFramePosition + currentFormPosition;
            }

        }

        private List<InputForm> forms { get; set; }

        public void Update ( GameTime gameTime )
        {
            foreach (var form in this.forms)
            {
                form.Update(gameTime);
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
            foreach ( var form in this.forms )
            {
                form.Draw (spriteBatch);
            }

        }

        public void HandleInput ( GameTime gameTime )
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState ( );
            
            if ( currentKeyboardState.IsKeyDown (Keys.Enter) )
            {
                //TODO: Send info to DB to check if login is OK
            }
            else if ( currentKeyboardState.IsKeyDown (Keys.Tab) && oldKeyboardState.IsKeyUp(Keys.Tab) )
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
            else if ( currentKeyboardState.IsKeyDown (Keys.Escape) )
            {
                //TODO: Go back to menu screen. PopScreen ?
            }

            for (int i = 0; i < forms.Count; i++)
            {
                if (currentlyHoveredForm == i)
                {
                    forms[i].HandleInput(gameTime);
                }
            }
        }

    }
}
