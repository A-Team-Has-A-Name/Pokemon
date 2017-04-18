namespace Pokemon.Client.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    public interface IGameScreenManager : IDisposable
    {
        void ChangeScreen(IGameScreen screen);
        void PushScreen(IGameScreen screen);
        void PopScreen();

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void HandleInput(GameTime gameTime);
        void ChangeBetweenScreens(IGameScreen screen);
        void Exit();

        event Action OnGameExit;
    }
}
