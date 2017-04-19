namespace Pokemon.Client.UI_Elements.Windows
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Textures;
    using Interfaces;

    public abstract class Window
    {
        private const int textureSide = 30;

        private Texture2D texture;
        public readonly Vector2 Position;
        public int CurrentHeight;
        public int CurrentWidth;
        public bool IsDone;
        public int Width;
        public int Height;

        public Window(Vector2 position, int width, int height)
        {
            this.Position = position;
            this.Width = width;
            this.Height = height;
            this.texture = TextureLoader.ChatWindowBackground;
            this.CurrentWidth = textureSide * 3;
            this.CurrentHeight = textureSide * 3;
        }

        public virtual void Update(GameTime gameTime)
        {
            if(this.CurrentWidth < this.Width)
            {               
                this.CurrentWidth += 45;

                if(this.CurrentWidth > this.Width)
                {
                    this.CurrentWidth = this.Width;
                }
            }

            if(this.CurrentHeight < this.Height)
            {
                this.CurrentHeight += 4;

                if(this.CurrentHeight > this.Height)
                {
                    this.CurrentHeight = this.Height;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DrawCorners(spriteBatch);
            DrawSides(spriteBatch);
            DrawTopAndBottom(spriteBatch);
            DrawMiddle(spriteBatch);
            //spriteBatch.Draw(texture, new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Width, this.Height), Color.White);
        }

        private void DrawTopAndBottom(SpriteBatch spriteBatch)
        {
            int width = this.CurrentWidth - (textureSide * 2);
            int height = this.CurrentHeight - (textureSide * 2);

            var frameRectTop = new Rectangle(textureSide, 0, textureSide, textureSide);
            var destinationRectTop = new Rectangle((int)this.Position.X + textureSide, (int)this.Position.Y, width, textureSide);

            int yBot = (int)this.Position.Y + (this.CurrentHeight - textureSide);
            var frameRectBot = new Rectangle(textureSide, textureSide * 2, textureSide, textureSide);
            var destinationRectBot = new Rectangle((int)this.Position.X + textureSide, yBot, width, textureSide);

            spriteBatch.Draw(texture, destinationRectTop, frameRectTop, Color.White);
            spriteBatch.Draw(texture, destinationRectBot, frameRectBot, Color.White);
        }

        private void DrawSides(SpriteBatch spriteBatch)
        {
            int width = this.CurrentWidth - (textureSide * 2);
            int height = this.CurrentHeight - (textureSide * 2);

            var frameRectLeft = new Rectangle(0, textureSide, textureSide, textureSide);
            var destinationRectLeft = new Rectangle((int)this.Position.X, (int)this.Position.Y + textureSide, textureSide, height);

            int xRight = (int)this.Position.X + (this.CurrentWidth - textureSide);
            var frameRectRight = new Rectangle(textureSide * 2, textureSide , textureSide, textureSide);
            var destinationRectRight = new Rectangle(xRight, (int)this.Position.Y + textureSide, textureSide, height);

            spriteBatch.Draw(texture, destinationRectLeft, frameRectLeft, Color.White);
            spriteBatch.Draw(texture, destinationRectRight, frameRectRight, Color.White);
        }

        private void DrawCorners(SpriteBatch spriteBatch)
        {          
            var topLeftFrame = new Rectangle(0, 0, textureSide, textureSide);

            var topRightFrame = new Rectangle(textureSide * 2, 0, textureSide, textureSide);
            int xRight = (int)this.Position.X + (this.CurrentWidth - textureSide);

            var botLeftFrame = new Rectangle(0, textureSide * 2, textureSide, textureSide);
            int yBot = (int)this.Position.Y + (this.CurrentHeight - textureSide);

            var botRightFrame = new Rectangle(textureSide * 2, textureSide * 2, textureSide, textureSide);


            //BotLeft
            spriteBatch.Draw(texture, new Vector2((int)this.Position.X, yBot), botLeftFrame, Color.White);
            //BotRight
            spriteBatch.Draw(texture, new Vector2(xRight, yBot), botRightFrame, Color.White);
            //TopLeft
            spriteBatch.Draw(texture, new Vector2((int)this.Position.X, (int)this.Position.Y), topLeftFrame, Color.White);
            //TopRight
            spriteBatch.Draw(texture, new Vector2(xRight, (int)this.Position.Y), topRightFrame, Color.White);

        }

        private void DrawMiddle(SpriteBatch spriteBatch)
        {
            int width = this.CurrentWidth - (textureSide * 2);
            int height = this.CurrentHeight - (textureSide * 2);

            var frameRect = new Rectangle(textureSide, textureSide, textureSide, textureSide);
            var destinationRect = new Rectangle((int)this.Position.X + textureSide, (int)this.Position.Y + textureSide, width, height);

            spriteBatch.Draw(texture, destinationRect, frameRect, Color.White);
        }
    }
}
