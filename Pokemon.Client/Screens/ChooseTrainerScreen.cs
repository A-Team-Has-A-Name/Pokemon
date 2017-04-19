using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pokemon.Client.Content;
using Pokemon.Client.Core;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;
using Pokemon.Client.Interfaces;
using Pokemon.Client.Textures;
using Pokemon.Client.UI_Elements.Windows;

namespace Pokemon.Client.Screens
{
    public class ChooseTrainerScreen:IGameScreen
    {
        private bool exitGame;

        private readonly GameScreenManager screenManager;
        public Window window;
        public WindowManager windowManager;

        private List<Trainer> trainers { get; set; }

        public int currentlyHoveredTrainer { get; set; }

        public bool IsPaused { get; private set; }

        public ChooseTrainerScreen ( GameScreenManager screenManager )
        {
            this.screenManager = screenManager;
        }

        public void Initialize ( ContentManager content )
        {
           
        }

        public void Pause ( )
        {
            IsPaused = true;
        }

        public void Resume ( )
        {
            IsPaused = false;
        }

        public void Update ( GameTime gameTime )
        {

            
        }

        public void Draw ( GameTime gameTime, SpriteBatch spriteBatch )
        {
            //spriteBatch.Draw (TextureLoader.TrainerMenuBackground,new Vector2(0,0), new Rectangle (1920 - SessionEngine.WindowWidth, 1080 - SessionEngine.WindowHeight, SessionEngine.WindowWidth,SessionEngine.WindowHeight), Color.White);
            spriteBatch.Draw (TextureLoader.TrainerMenuBackground,new Rectangle(0,0,SessionEngine.WindowWidth,SessionEngine.WindowHeight), new Rectangle (0,0, 1920,1080), Color.White);

        }

        public void HandleInput ( GameTime gameTime )
        {
            
        }

        public void Dispose ( )
        {

        }
    }
}
