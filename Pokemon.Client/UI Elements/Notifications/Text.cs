namespace Pokemon.Client.UI_Elements
{
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public class Text : IUpdatable
    {
        public Text() { }

        public Text(string message, SpriteFont font, Vector2 position, Color color)
        {
            this.Message = message;
            this.SpriteFont = font;
            this.Position = position;
            this.Color = color;
        }
        
        public string Message { get; set; }

        public SpriteFont SpriteFont { get; set; }

        public Vector2 Position { get; set; }

        public Color Color { get; set; }

        public bool IsHovered { get; set; }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Message, Position,Color);
        }
    }
}
