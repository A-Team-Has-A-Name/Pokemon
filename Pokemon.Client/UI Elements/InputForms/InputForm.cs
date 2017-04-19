
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.Interfaces;
using Pokemon.Client.Textures;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Pokemon.Client.UI_Elements.InputForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class InputForm : Interfaces.IDrawable, IUpdatable
    {
        public Texture2D SpriteSheet { get; set; }

        public Vector2 Position { get; set; }

        internal Color DefaultSpriteColour;

        internal Color HoverSpriteColour;

        public bool isHovered { get; set; }

        public int TextureWidth { get; set; }

        public int TextureHeight { get; set; }

        public SpriteFont textFont { get; set; }

        internal Text DescriptionOfField { get; set; }

        internal bool isSecured { get; set; }

        internal string TextString;

        private KeyboardState currentKeyboardState;

        private KeyboardState oldKeyboardState;

        public InputForm ( )
        {
            this.TextString = string.Empty;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            double scaleForm = TextureLoader.TextBoxScale;
            Rectangle targetRectangle = new Rectangle((int) this.Position.X, (int) this.Position.Y,
                TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth);
            targetRectangle.Width = (int) (targetRectangle.Width*scaleForm);
            targetRectangle.Height = (int) (targetRectangle.Height*scaleForm);

            if (isHovered)
            {
                spriteBatch.Draw(this.SpriteSheet, targetRectangle,
                    new Rectangle(0, 0, TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth), HoverSpriteColour);
            }
            else
            {
                spriteBatch.Draw(this.SpriteSheet, targetRectangle,
                    new Rectangle(0, 0, TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth), DefaultSpriteColour);
            }

            


            DescriptionOfField.Position = this.Position + new Vector2(0, -40f);
            DescriptionOfField.Draw(spriteBatch);

            string textToShow = TextString;
            if (isSecured)
            {
                textToShow = new string('*', TextString.Length);
            }

            

            Vector2 formTextPosition = new Vector2(20, 25) + this.Position;
            spriteBatch.DrawString(this.textFont, textToShow, formTextPosition, Color.Black);
            //scaling spriteBatch.DrawString(DescriptionOfField.SpriteFont, textToShow, formTextPosition, Color.Black, 0f,Vector2.One, new Vector2(5, 5), SpriteEffects.None, 0f);
        }

        public void Update ( GameTime gameTime )
        {
        }

        public void HandleInput ( GameTime gameTime )
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState ( );

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys ( );

            foreach ( Keys key in pressedKeys )
            {
                if ( oldKeyboardState.IsKeyUp (key) )
                {
                    if ( key == Keys.Back && TextString.Length > 0 )
                    {
                        TextString = TextString.Remove (TextString.Length - 1, 1);
                    }
                    else if ( key == Keys.Space )
                    {
                        TextString = TextString.Insert (TextString.Length, " ");
                    }
                    else
                    {
                        string keyString = key.ToString ( );
                        bool isUpperCase = ( ( Control.IsKeyLocked (System.Windows.Forms.Keys.CapsLock) &&
                                             ( !currentKeyboardState.IsKeyDown (Keys.RightShift) &&
                                              !currentKeyboardState.IsKeyDown (Keys.LeftShift) ) ) ||
                                            ( !Control.IsKeyLocked (System.Windows.Forms.Keys.CapsLock) &&
                                             ( currentKeyboardState.IsKeyDown (Keys.RightShift) ||
                                              currentKeyboardState.IsKeyDown (Keys.LeftShift) ) ) );

                        if ( keyString.Length == 1 )
                        {
                            TextString += isUpperCase ? keyString.ToUpper ( ) : keyString.ToLower ( );
                        }
                    }
                }
            }
        }
    }
}

