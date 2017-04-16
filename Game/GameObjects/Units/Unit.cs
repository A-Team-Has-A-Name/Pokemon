namespace Pokemon.Client.GameObjects.Units
{
    using System;
    using Pokemon.Client.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Unit : GameObject, IUnit
    {
        private int basicAnimationFrameCount;
        private int currentFrame;
        private float defaultMovementSpeed;
        private int delay;
        private bool isFacingDown;
        private bool isFacingUp;
        private bool isFacingLeft;
        private bool isFacingRight;
        private float movementSpeed;
        private Rectangle frameRect;
        private double timer;
        private bool isMoving;

        protected Unit() : base()
        {
            this.Timer = 0.0;
            this.CurrentFrame = 0;
            this.frameRect = new Rectangle();
            this.IsFacingLeft = false;
            this.IsFacingRight = false;
            this.IsFacingUp = false;
            this.IsFacingDown = true;
            this.IsMoving = false;
        }

        //Animation
        public int BasicAnimationFrameCount
        {
            get
            {
                return this.basicAnimationFrameCount;
            }
            protected set
            {
                this.basicAnimationFrameCount = value;
            }
        }

        public int CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }
            protected set
            {
                this.currentFrame = value;
            }
        }

        public int Delay
        {
            get
            {
                return this.delay;
            }
            protected set
            {
                this.delay = value;
            }
        }

        public Rectangle FrameRect
        {
            get
            {
                return this.frameRect;
            }
            protected set
            {
                this.frameRect = value;
            }
        }

        public double Timer
        {
            get
            {
                return this.timer;
            }
            protected set
            {
                this.timer = value;
            }
        }

        protected void BasicAnimationLogic(GameTime gameTime, int delay, int basicAnimationFrameCount)
        {
            this.Timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer >= delay)
            {
                this.CurrentFrame++;

                if (this.CurrentFrame >= basicAnimationFrameCount)
                {
                    this.CurrentFrame = 0;
                }

                this.Timer = 0.0;
            }
        }


        public void ResetAnimation()
        {
            this.CurrentFrame = 0;
            this.Timer = 0.0;
        }


        //FacingDirection
        public bool IsFacingDown
        {
            get
            {
                return this.isFacingDown;
            }

            set
            {
                this.isFacingDown = value;
            }
        }

        public bool IsFacingLeft
        {
            get
            {
                return this.isFacingLeft;
            }

            set
            {
                this.isFacingLeft = value;
            }
        }

        public bool IsFacingRight
        {
            get
            {
                return this.isFacingRight;
            }

            set
            {
                this.isFacingRight = value;
            }
        }

        public bool IsFacingUp
        {
            get
            {
                return this.isFacingUp;
            }

            set
            {
                this.isFacingUp = value;
            }
        }

        //Movement
        protected void ManageMovement(GameTime gameTime)
        {
            if (this.IsFacingRight && this.IsMoving)
            {
                this.X += this.MovementSpeed;
            }
            else if (this.IsFacingLeft && this.IsMoving)
            {
                this.X -= this.MovementSpeed;
            }
            else if (this.IsFacingUp && this.IsMoving)
            {
                this.Y -= this.MovementSpeed;
            }
            else if (this.IsFacingDown && this.IsMoving)
            {
                this.Y += this.MovementSpeed;
            }
        }

        public float DefaultMovementSpeed
        {
            get
            {
                return this.defaultMovementSpeed;
            }
            protected set
            {
                this.defaultMovementSpeed = value;
            }
        }

        public float MovementSpeed
        {
            get
            {
                return this.movementSpeed;
            }
            protected set
            {
                this.movementSpeed = value;
            }
        }

        public bool IsMoving
        {
            get
            {
                return this.isMoving;
            }
            set
            {
                this.isMoving = value;
            }
        }

        public void ClearMovement()
        {
            this.IsFacingRight = false;
            this.IsFacingLeft = false;
            this.IsFacingUp = false;
            this.IsFacingDown = false;
            this.IsMoving = false;
        }

        public void ValidateMovementRight()
        {
            this.ClearMovement();
            this.IsFacingRight = true;
            this.IsMoving = true;
        }

        public void ValidateMovementLeft()
        {
            this.ClearMovement();
            this.IsFacingLeft = true;
            this.IsMoving = true;
        }

        public void ValidateMovementUp()
        {
            this.ClearMovement();
            this.IsFacingUp = true;
            this.IsMoving = true;
        }

        public void ValidateMovementDown()
        {
            this.ClearMovement();
            this.IsFacingDown = true;
            this.IsMoving = true;
        }

        public void MakeUnitIdle()
        {
            this.IsMoving = false;
        }

        //Abstract
        public abstract void Update(GameTime gameTime);
        protected abstract void UpdateBoundingBox();
        protected abstract void ManageAnimation(GameTime gameTime);
    }
}
