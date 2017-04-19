namespace Pokemon.Client.UI_Elements.Windows.Message
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;

    public class MessagePage : IUpdatable
    {
        private const int CharacterDelay = 100;
        private SpriteFont font;
        private char[] text;
        private Vector2 position;
        private int index;
        private double counter;
        private string currentText;

        public bool IsDone { get; set; }

        public MessagePage(string text, Vector2 position, SpriteFont font)
        {
            this.text = text.ToCharArray();
            this.position = position;
            this.font = font;
            index = 0;
            counter = 0;
            currentText = "";
        }

        public void Update(GameTime gameTime)
        {
            if(index >= text.Length)
            {
                return;
            }
            counter += gameTime.ElapsedGameTime.TotalMilliseconds;
            if(counter > CharacterDelay)
            {
                counter = 0;
                index++;
                if(index == text.Length - 1)
                {
                    IsDone = true;
                }

                UpdateText();
            }
        }

        public void UpdateText()
        {
            currentText = "";
            for (int i = 0; i < index; i++)
            {
                currentText += text[i];
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, currentText, position, Color.Gray);
        }
    }
}