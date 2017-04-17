namespace Pokemon.Client.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public interface IGameScreen : IDisposable
    {
        bool IsPaused { get; }

        void Pause();
        void Resume();

        void Initialize(ContentManager content);

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void HandleInput(GameTime gameTime);

        void ChangeBetweenScreens();
    }
}
