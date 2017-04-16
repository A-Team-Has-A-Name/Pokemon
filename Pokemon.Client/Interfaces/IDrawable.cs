namespace Pokemon.Client.Interfaces
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IDrawable
    {
        int TextureWidth { get; }

        int TextureHeight { get; }

        Texture2D SpriteSheet { get; }

        void Draw(SpriteBatch spriteBatch);
    }
}
