﻿namespace Pokemon.Client.GameObjects.Units.PlayableCharacters
{
    using Microsoft.Xna.Framework.Graphics;
    using Pokemon.Client.Textures;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.Input;
    using Models;
    using NonPlayableCharacters;
    using System.Collections.Generic;

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

        public string Name { get; set; }
        public List<Pokemon> CaughtPokemon { get; set; }
        public Pokemon[] Team { get; set; }

        public Trainer(TrainerModel model)
        {
            this.Name = model.Name;

            this.Position = new Vector2(100, 100);
            this.BoundingBox = new Rectangle(
                (int)this.X,
                (int)this.Y,
                Width,
                Height);

            this.SpriteSheet = TextureLoader.TrainerSheet;
            this.TextureHeight = spriteHeight;
            this.TextureWidth = spriteWidth;
          
            this.DefaultMovementSpeed = TrainerDefaultMovementSpeed;
            this.MovementSpeed = TrainerDefaultMovementSpeed;

            this.Delay = TrainerAnimationDelay;
            this.BasicAnimationFrameCount = TrainerWalkingFrameCount;
            this.IsSurprised = false;
        }

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsSurprised)
            {
                this.GetSurprised(spriteBatch);
                this.IsMoving = false;
            }

            spriteBatch.Draw(this.SpriteSheet, this.BoundingBox, this.FrameRect, Color.White);
        }

        //Collision
        protected override void UpdateBoundingBox()
        {
            this.BoundingBoxX = (int)this.X;
            this.BoundingBoxY = (int)this.Y;
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

        public void GetSurprised(SpriteBatch spriteBatch)
        {
            //get coordinates of surprised sprite
            int x = 0;
            int y = 4 * this.TextureHeight;
            int width = 37;
            int height = 36;

            int xPos = (int)this.X + 25;
            int yPos = (int)this.Y - 25;

            var frameRect = new Rectangle(x, y, width, height);
            spriteBatch.Draw(this.SpriteSheet, new Vector2(xPos, yPos), frameRect, Color.White);
        }

    }
}
