using Microsoft.Xna.Framework.Media;

namespace Pokemon.Client
{
    using Core.Engines;
    using GameObjects.Units.PlayableCharacters;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Screens;
    using Textures;

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Trainer trainer;
        GameScreenManager screenManager;
        private Song mainTheme { get; set; }
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
            SessionEngine.Load(this.Content);
            SessionEngine.InitializeTrainer();
            trainer = SessionEngine.Trainer;
            screenManager.ChangeScreen(new StartUpScreen(screenManager));
            mainTheme = TextureLoader.mainTheme;
            MediaPlayer.Play(mainTheme);
            MediaPlayer.IsRepeating = true;
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
            //screenManager.ChangeBetweenScreens();

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
