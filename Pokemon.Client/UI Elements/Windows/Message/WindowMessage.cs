namespace Pokemon.Client.UI_Elements.Windows.Message
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Text;
    using System;
    using Core.Engines;
    using Core;

    public class MessageWindow : Window
    {
        public string text;
        private Vector2 margin;
        private List<MessagePage> pages;
        private int pageIndex;
        private SpriteFont font;
        private double counter;

        public int Id { get; set; }
        public int MaxNumberRows { get; set; }
        public SpriteFont Font
        {
            get { return this.font;  }
            set { this.font = value; }
        }
        public Color Color { get; internal set; }

        public MessageWindow(Vector2 position, int width, int height, string text, int id, int maxRows) : base(position, width, height)
        {
            this.Id = id;
            this.text = text;
            pages = new List<MessagePage>();
            pageIndex = 0;
            margin = new Vector2(30);
            font = SessionEngine.PokemonFont;
            MaxNumberRows = maxRows;
            CreatePages(font);
        }

        public MessageWindow(Vector2 position, int width, int height, int id) : base(position, width, height)
        {
            this.Id = id;
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

                if (font.MeasureString(rowText).X > Width - margin.X)
                {
                    rowText.Remove(oldRowLength, rowText.Length - oldRowLength);
                    if (rowIndex == MaxNumberRows - 1)
                    {
                        pages.Add(new MessagePage(rowText.ToString(), Position + margin, font, false));
                        rowText.Clear();
                        rowIndex = 0;
                    }
                    else
                    {
                        rowText.Append($"{Environment.NewLine}");
                    }
                }
                else
                {
                    index++;
                }
            }

            if (rowText.Length > 0)
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
            if (this.IsDone)
            {
                return;
            }
            if(pages[pages.Count - 1].IsDone)
            {
                this.counter += gameTime.ElapsedGameTime.TotalMilliseconds;
                if (this.counter > 500)
                {
                    this.counter = 0.0;
                    this.IsDone = true;
                    WorldEngine.WindowManager.FinishedMessageWindow(this.Id, this);
                    return;             
                }
            }

            if (this.CurrentWidth == this.Width)
            {

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
            if (this.IsDone)
            {
                return;
            }
            base.Draw(spriteBatch);
            pages[pageIndex].Draw(spriteBatch);    
        }
    }
}
