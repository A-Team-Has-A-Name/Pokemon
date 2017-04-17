
namespace Pokemon.Client.UI_Elements
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Pokemon.Client.Interfaces;
    using Pokemon.Client.Textures;

    using System;
    using Microsoft.Xna.Framework;

    internal enum ButtonState
    {
        None,
        Hovered,
        Clicked
    }

    public class Button : Interfaces.IDrawable, IUpdatable
    {
        public  Texture2D SpriteSheet { get; set; }

        internal Color DefaultSpriteColour;

        internal Color HoverSpriteColour;

        internal Text Text;

        internal Color DefaultTextColour;

        internal Color HoverTextColour;

        private ButtonState previousButtonState;

        private ButtonState currentButtonState;

        private Action onClicked;

        private Action onHovered;

        public int TextureWidth { get; }

        public int TextureHeight { get; }

        internal event Action OnClicked
        {
            add { onClicked += value; }
            remove { onClicked -= value; }
        }

        internal event Action OnHovered
        {
            add { onHovered += value; }
            remove { onHovered -= value; }
        }

        internal void HandleInput ( KeyboardState keyboardState, bool IsHovered )
        {
            if ( IsHovered )
            {
                currentButtonState = ButtonState.Hovered;

                if ( keyboardState.IsKeyDown (Keys.Enter) )
                {
                    currentButtonState = ButtonState.Clicked;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Text.Color = DefaultTextColour;

            if ( currentButtonState == ButtonState.Hovered )
            {
                Text.Color = HoverTextColour;
            }
        }

        private void FireEvents ( )
        {
            if ( currentButtonState != previousButtonState )
            {
                switch ( currentButtonState )
                {
                    case ButtonState.Hovered:
                        if ( onHovered != null )
                        {
                            onHovered ( );
                        }
                        break;
                    case ButtonState.Clicked:
                        if ( onClicked != null )
                        {
                            onClicked ( );
                        }
                        break;
                }
            }
        }

        public void Draw ( SpriteBatch spriteBatch )
        {
            if ( currentButtonState == ButtonState.Hovered )
            {
                spriteBatch.Draw (this.SpriteSheet, new Vector2 ( ), new Rectangle (0, 0, 200, 100), HoverSpriteColour);
            }
            else
            {
                spriteBatch.Draw (this.SpriteSheet, new Vector2 ( ), new Rectangle (0, 0, 200, 100), DefaultSpriteColour);
            }

            Text.Draw (spriteBatch);
        }
    }
}
