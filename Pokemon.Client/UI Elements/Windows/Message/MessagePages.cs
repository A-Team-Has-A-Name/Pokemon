namespace Pokemon.Client.UI_Elements.Windows.Message
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Interfaces;

    public class MessagePage : IUpdatable
    {
        private const int CharacterDelay = 50;
        private const int repeatLoadingDots = 3;
        private SpriteFont font;
        private char[] text;
        private char[] loadDots;
        private int loadDotsIndex;
        private int repeatedLoadingDots;
        private Vector2 position;
        private int index;
        private double counter;
        private string currentText;
        private bool isLoading;

        public bool IsDone { get; set; }

        public MessagePage(string text, Vector2 position, SpriteFont font, bool isLoading)
        {
            this.text = text.ToCharArray();
            this.position = position;
            this.font = font;
            this.index = 0;
            this.counter = 0;
            this.currentText = "";
            this.loadDots = (".  .  .").ToCharArray();
            this.loadDotsIndex = 0;
            this.repeatedLoadingDots = 0;
            this.isLoading = isLoading;
        }

        public void Update(GameTime gameTime)
        {            
            if(index >= text.Length && !isLoading || index >= text.Length + loadDots.Length && isLoading)
            {
                return;
            }

            counter += gameTime.ElapsedGameTime.TotalMilliseconds;

            if(counter > CharacterDelay)
            {
                counter = 0;
                if(index < text.Length - 1)
                {
                    index++;
                }

                if(index == text.Length - 1 && !isLoading)
                {
                        IsDone = true;
                }
                UpdateText();

                if (index == text.Length - 1 && isLoading)
                {
                    LoadDots(gameTime);
                }
            }
        }

        public void LoadDots(GameTime gameTime)
        {
            if(loadDotsIndex >= loadDots.Length && repeatedLoadingDots == repeatLoadingDots)
            {
                isLoading = false;
                IsDone = true;
                return;
            }

            if (loadDotsIndex >= loadDots.Length && repeatedLoadingDots <= repeatLoadingDots)
            {
                repeatedLoadingDots++;
                currentText = currentText.Substring(0, text.Length);
                loadDotsIndex = 0;
            }
         
            loadDotsIndex++;

            for (int i = 0; i < loadDotsIndex; i++)
            {
                currentText += loadDots[i];
            }
            
        }

        public void UpdateText()
        {
            currentText = "";

            for (int i = 0; i <= index; i++)
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