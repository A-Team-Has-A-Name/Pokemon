namespace Pokemon.Client.GameObjects
{
    using System;
    using Pokemon.Client.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Core;
    using Core.Engines;

    public abstract class GameObject : IGameObject
    {
        private Vector2 position;
        private Texture2D spriteSheet;
        private Rectangle boundingBox;
        private int textureWidth;
        private int textureHeight;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        public float X
        {
            get { return this.position.X; }
            set
            {
                if (value > SessionEngine.WindowWidth - TextureWidth)
                {
                    value = SessionEngine.WindowWidth - TextureWidth;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                this.position.X = value;           
            } 
        }

        public float Y
        {
            get { return this.position.Y; }
            set
            {
                if (value > SessionEngine.WindowHeight - TextureHeight)
                {
                    value = SessionEngine.WindowHeight - TextureHeight;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                this.position.Y = value;
            } 
        }

        public int TextureWidth
        {
            get
            {
                return this.textureWidth;
            }
            protected set
            {
                this.textureWidth = value;
            }
        }

        public int TextureHeight
        {
            get
            {
                return this.textureHeight;
            }
            protected set
            {
                this.textureHeight = value;
            }
        }

        public Texture2D SpriteSheet
        {
            get
            {
                return this.spriteSheet;
            }
            protected set
            {
                this.spriteSheet = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }

            set
            {
                this.boundingBox = value;
            }
        }

        public int BoundingBoxX
        {
            get
            {
                return this.boundingBox.X;
            }
            set
            {
                this.boundingBox.X = value;
            }
        }

        public int BoundingBoxY
        {
            get
            {
                return this.BoundingBox.Y;
            }
            set
            {
                this.boundingBox.Y = value;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
