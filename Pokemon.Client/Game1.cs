namespace Pokemon.Client
{
    using Core;
    using Core.Engines;
    using Data;
    using GameObjects.Units.PlayableCharacters;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Screens;
    using Textures;

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Trainer trainer;
        GameScreenManager screenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //this.Window.IsBorderless = true;
            //this.graphics.IsFullScreen = true;
            this.Window.AllowAltF4 = true;
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = SessionEngine.WindowWidth;
            graphics.PreferredBackBufferHeight = SessionEngine.WindowHeight;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {            
            base.Initialize();
            SessionEngine.InitializeTrainer();
            trainer = SessionEngine.Trainer;
            screenManager.ChangeScreen(new WorldScreen(screenManager));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenManager = new GameScreenManager(spriteBatch, Content);
            screenManager.OnGameExit += Exit;

            TextureLoader.Load(this.Content);
        }


        protected override void UnloadContent()
        {
            if(screenManager != null)
            {
                screenManager.Dispose();

                screenManager = null;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            screenManager.ChangeBetweenScreens();

            screenManager.HandleInput(gameTime);
            screenManager.Update(gameTime);
          
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            screenManager.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
