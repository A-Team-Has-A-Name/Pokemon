namespace Pokemon.Client.UI_Elements.Windows.Message
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Text;
    using System;
    using Core.Engines;

    public class MessageWindow : Window
    {
        private const int MaxNumberRows = 2;
        public string text;
        private Vector2 margin;
        private List<MessagePage> pages;
        private int pageIndex;
        private SpriteFont font;
        private double counter;

        public MessageWindow(Vector2 position, int width, int height, string text) : base(position, width, height)
        {
            this.text = text;
            pages = new List<MessagePage>();
            pageIndex = 0;
            margin = new Vector2(30);
            font = SessionEngine.PokemonFont;
            CreatePages(font);

        }
        public MessageWindow(Vector2 position, int width, int height) : base(position, width, height)
        {
            this.text = "";
            pages = new List<MessagePage>();
            pageIndex = 0;
            margin = new Vector2(30);
            font = SessionEngine.PokemonFont;
            this.counter = 0.0;
        }


        public void CreatePages(SpriteFont font)
        {
            var words = text.Split(' ');
            var rowText = new StringBuilder();
            var rowIndex = 0;
            var index = 0;

            while (index < words.Length)
            {
                var word = words[index];
                var oldRowLength = rowText.Length;
                rowText.Append($"{word} ");

                if(font.MeasureString(rowText).X > Width - margin.X)
                {
                    rowText.Remove(oldRowLength, rowText.Length - oldRowLength);
                    if(rowIndex == MaxNumberRows - 1)
                    {
                        pages.Add(new MessagePage(rowText.ToString(), Position + margin, font, false));
                        rowText.Clear();
                        rowIndex = 0;
                    }
                    else
                    {
                        rowText.Append($"{Environment.NewLine}{Environment.NewLine}");
                    }
                }
                else
                {
                    index++;
                }
            } 

            if(rowText.Length > 0)
            {
                pages.Add(new MessagePage(rowText.ToString(), Position + margin, font, false));
            }
        }
        
        public void AddPage(string text, bool isLoading)
        {
            pages.Add(new MessagePage(text, this.Position + this.margin, this.font, isLoading));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(this.CurrentWidth == this.Width)
            {
                if (IsDone)
                {
                    return;
                }
                if (this.pages[this.pageIndex].IsDone)
                {
                    if (this.pageIndex < this.pages.Count - 1)
                    {
                        this.counter += gameTime.ElapsedGameTime.TotalMilliseconds;
                        if (this.counter > 500)
                        {
                            this.counter = 0.0;
                            this.pageIndex++;
                        }
                    }
                }
                pages[pageIndex].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsDone)
            {
                return;
            }
            base.Draw(spriteBatch);
            pages[pageIndex].Draw(spriteBatch);    
        }
    }
}
