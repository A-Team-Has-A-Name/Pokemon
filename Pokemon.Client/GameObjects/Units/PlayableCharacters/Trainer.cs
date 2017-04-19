namespace Pokemon.Client.GameObjects.Units.PlayableCharacters
{
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Textures;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.Input;
    using Models;
    using NonPlayableCharacters;
    using System.Collections.Generic;
    using UI_Elements.Windows;
    using Core;
    using System;
    using Core.Engines;
    using UI_Elements.Windows.Message;
    using System.Linq;
    using PokemonDB.Data.Store;

    public class Trainer : Unit
    {
        private const int spriteWidth = 96;
        private const int spriteHeight = 96;
        private const int Height = 90;
        private const int Width = 90;
        private const float TrainerDefaultMovementSpeed = 5;
        private const int TrainerIdleFrameCount = 1;
        private const int TrainerWalkingFrameCount = 2;
        private const int TrainerAnimationDelay = 100;
        private WindowManager windowHandler;
        private TrainerModel model;

        public Trainer(TrainerModel model)
        {
            this.model = model;
            this.Id = model.Id;
            this.Name = model.Name;
            this.Position = new Vector2(100, 100);
            this.BoundingBox = new Rectangle((int)this.X, (int)this.Y, Width - 40, Height - 10);

            this.SpriteSheet = TextureLoader.TrainerSheet;
            this.TextureHeight = spriteHeight;
            this.TextureWidth = spriteWidth;

            this.DefaultMovementSpeed = TrainerDefaultMovementSpeed;
            this.MovementSpeed = TrainerDefaultMovementSpeed;

            this.Delay = TrainerAnimationDelay;
            this.BasicAnimationFrameCount = TrainerWalkingFrameCount;
            this.IsSurprised = false;
            this.windowHandler = WorldEngine.WindowManager;

            this.CaughtPokemon = new List<Pokemon>();
             AddPokemon();

            }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public List<Pokemon> CaughtPokemon { get; set; }
        public Pokemon[] Team { get; set; }

        public bool IsSurprised { get; set; }

        public override void Update(GameTime gameTime)
        {
            InputHandler.HandleInput(gameTime, this);
            if (IsSurprised)
            {
                this.IsMoving = false;
            }

            this.ManageAnimation(gameTime);
            this.ManageMovement(gameTime);
            this.UpdateBoundingBox();

        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsSurprised)
            {
                this.GetSurprised(spriteBatch);
                this.IsMoving = false;
            }

            spriteBatch.Draw(this.SpriteSheet, new Rectangle((int)this.X, (int)this.Y, this.TextureWidth, this.TextureHeight), this.FrameRect, Color.White);
            ///Draw bounding box for debugging
            //this.DrawBB(spriteBatch);
        }

        private void DrawBB(SpriteBatch spriteBatch)
        {
         
            spriteBatch.Draw(TextureLoader.TheOnePixel,this.BoundingBox, Color.AliceBlue);
        }

        //Collision
        protected override void UpdateBoundingBox()
        {
            this.BoundingBoxX = (int)this.X + 21;
            this.BoundingBoxY = (int)this.Y + 20;
        }

        //Animation
        protected override void ManageAnimation(GameTime gameTime)
        {
            if (this.IsMoving)
            {
                this.AnimateMoving(gameTime);
            }
            else
            {
                this.AnimateIdle(gameTime);
            }

        }

        protected void AnimateMoving(GameTime gameTime)
        {
            this.BasicAnimationLogic(gameTime, this.Delay, this.BasicAnimationFrameCount);

            int y = 0;

            if (this.IsFacingLeft)
            {
                y = this.TextureHeight;
            }
            else if (this.IsFacingDown)
            {
                y = this.TextureHeight * 2;
            }
            else if (this.IsFacingRight)
            {
                y = this.TextureHeight * 3;
            }

            this.FrameRect = new Rectangle(this.CurrentFrame * this.TextureWidth, y, this.TextureWidth, this.TextureHeight);          
        }

        protected void AnimateIdle(GameTime gameTime)
        {
            int y = 0;

            if (this.IsFacingLeft)
            {
                y = this.TextureHeight;
            }
            else if (this.IsFacingDown)
            {
                y = this.TextureHeight * 2;
            }
            else if (this.IsFacingRight)
            {
                y = this.TextureHeight * 3;
            }

            this.FrameRect = new Rectangle(0, y, this.TextureWidth, this.TextureHeight);
        }

        //Action
        public void GetSurprised(SpriteBatch spriteBatch)
        {
            int x = 0;
            int y = 4 * this.TextureHeight;
            int width = 37;
            int height = 36;

            int xPos = (int)this.X + 25;
            int yPos = (int)this.Y - 25;

            var frameRect = new Rectangle(x, y, width, height);
            spriteBatch.Draw(this.SpriteSheet, new Vector2(xPos, yPos), frameRect, Color.White);
        }

        //Other
        public TrainerModel GetCurrentModelState()
        {
            UpdateModel();
            return this.model;
        }

        private void UpdateModel()
        {
            this.model.Name = this.Name;
            if(this.model.CaughtPokemon.Count < this.CaughtPokemon.Count)
            {
                foreach (var poke in this.CaughtPokemon)
                {
                    if(!this.model.CaughtPokemon.Where(p => p.Id == poke.Id).Any())
                    {
                        this.model.CaughtPokemon.Add(poke.GetCurrentModelState());
                    }
                }

            }
        }

        public void CatchPokemon(Pokemon pokemon)
        {
            pokemon.TrainerId = this.Id;
            pokemon.IsUpdated = true;
            this.CaughtPokemon.Add(pokemon);
        }
        public void AddPokemon()
        {
            var pokemon = PokemonStore.GetTrainerCaughtPokemon(this.Id);
            foreach (var p in pokemon)
            {
                this.CaughtPokemon.Add(new Pokemon(p));
            }
        }

        public List<PokemonModel> GetCaughtPokemonModelsForUpdate()
        {
            var result = new List<PokemonModel>();
            foreach (var p in this.CaughtPokemon)
            {
                if (p.IsUpdated)
                {
                    result.Add(p.GetCurrentModelState());
                }
            }
            return result;
        }

    }
}
