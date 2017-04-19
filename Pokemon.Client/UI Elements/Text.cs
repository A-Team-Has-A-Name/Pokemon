namespace Pokemon.Client.UI_Elements
{
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public class Text : IUpdatable
    {
        public string Message { get; set; }

        public SpriteFont SpriteFont { get; set; }

        public Vector2 Position { get; set; }

        public Color Color { get; set; }

        public bool IsHovered { get; set; }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Message, Position,Color);
        }
    }
}
