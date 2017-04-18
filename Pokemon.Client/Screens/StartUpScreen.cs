using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.Interfaces;
using Pokemon.Client.UI_Elements;

namespace Pokemon.Client.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUpScreen : IGameScreen
    {
        private readonly GameScreenManager screenManager;

        private bool exitGame;

        private List<Text> Texts;

        private List<Button> Buttons;

        public bool IsPaused { get; private set; }

        public StartUpScreen ( GameScreenManager screenManager )
        {
            this.screenManager = screenManager;
        }

        public void Pause()
        {
            this.IsPaused = true;
        }

        public void Resume()
        {
            this.IsPaused = false;
        }

        public void Initialize(ContentManager content)
        {
            StartUpEngine.GenerateButtons(content);
            StartUpEngine.InitializeUpdatableObjects(content);
            StartUpEngine.InitializeDrawableObjects(content);
            this.Buttons = StartUpEngine.Buttons;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var updatableObject in StartUpEngine.UpdatableObjects)
            {
                updatableObject.Update(gameTime);
            }   
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var drawableObject in StartUpEngine.DrawableObjects)
            {
                drawableObject.Draw(spriteBatch);
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            KeyboardState KS = Keyboard.GetState();

            //For debugging purposes - quick access to WorldScreen
            if (KS.IsKeyDown(Keys.W))
            {
                screenManager.ChangeBetweenScreens(new WorldScreen(screenManager));
            }

            foreach (var button in Buttons)
            {
                //TODO: Fix the hover management system
                button.HandleInput(KS,false);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
