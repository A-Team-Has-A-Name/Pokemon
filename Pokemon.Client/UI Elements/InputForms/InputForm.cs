
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

    public class InputForm : Interfaces.IDrawable, IUpdatable
    {
        public Texture2D SpriteSheet { get; set; }

        public static int MaximumLength = 15;

        public static int MinimumLength = 3;

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

        public void Draw ( SpriteBatch spriteBatch )
        {

            double scaleForm = TextureLoader.TextBoxScale;
            Rectangle targetRectangle = new Rectangle (( int ) this.Position.X, ( int ) this.Position.Y,
                TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth);
            targetRectangle.Width = ( int ) ( targetRectangle.Width * scaleForm );
            targetRectangle.Height = ( int ) ( targetRectangle.Height * scaleForm );

            if ( isHovered )
            {
                spriteBatch.Draw (this.SpriteSheet, targetRectangle,
                    new Rectangle (0, 0, TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth), HoverSpriteColour);
            }
            else
            {
                spriteBatch.Draw (this.SpriteSheet, targetRectangle,
                    new Rectangle (0, 0, TextureLoader.TextBoxWidth, TextureLoader.TextBoxHeigth), DefaultSpriteColour);
            }




            DescriptionOfField.Position = this.Position + new Vector2 (0, -40f);
            DescriptionOfField.Draw (spriteBatch);

            string textToShow = TextString;
            if ( isSecured )
            {
                textToShow = new string ('*', TextString.Length);
            }



            Vector2 formTextPosition = new Vector2 (20, 25) + this.Position;
            spriteBatch.DrawString (this.textFont, textToShow, formTextPosition, Color.Black);
            //scaling spriteBatch.DrawString(DescriptionOfField.SpriteFont, textToShow, formTextPosition, Color.Black, 0f,Vector2.One, new Vector2(5, 5), SpriteEffects.None, 0f);
        }

        public void Update ( GameTime gameTime )
        {
        }

        public void HandleInput ( GameTime gameTime )
        {
            string tempString = TextString;

            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState ( );

            Keys[] pressedKeys;
            pressedKeys = currentKeyboardState.GetPressedKeys ( );
            bool monkeysign = (pressedKeys.Contains(Keys.LeftShift) || pressedKeys.Contains (Keys.RightShift) ) && pressedKeys.Contains(Keys.D2);
            if (monkeysign && oldKeyboardState.IsKeyUp(Keys.D2) && !isSecured)
            {
                TextString = TextString.Insert (TextString.Length, "@");
                return;
            }
           

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
                    else if (key == Keys.OemPeriod)
                    {
                        TextString = TextString.Insert (TextString.Length, ".");
                    }
                    else if ( key == Keys.D0 || key == Keys.D1 || key == Keys.D2 || key == Keys.D3 || key == Keys.D4 || key == Keys.D5 || key == Keys.D6 || key == Keys.D7 || key == Keys.D8 || key == Keys.D9 )
                    {
                        TextString = TextString.Insert (TextString.Length, key.ToString());
                        TextString = TextString.Remove(TextString.Length - 2,1);
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

            if (TextString.Length > MaximumLength )
            {
                TextString = tempString;
            }

        }
    }
}

