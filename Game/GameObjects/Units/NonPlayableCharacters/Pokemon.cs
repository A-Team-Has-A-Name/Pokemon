namespace Pokemon.Client.GameObjects.Units.NonPlayableCharacters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;
    using Textures;  

    public class Pokemon : GameObject, IUpdatable, IDamagable
    {
        private const int pokemonSpriteHeight = 80;
        private const int pokemonSpriteWidth = 80;

        private int health;
        private bool isDefeated;
        private bool isEncountered;
        private bool isHidden;
        private Rectangle frameRect;

        public Pokemon(Vector2 pos, Vector2 spritePos)
        {
            this.Position = pos;
            this.SpriteSheet = TextureLoader.PokemonSheet;
            this.isHidden = true;
            this.frameRect = new Rectangle((int)this.X, (int)this.Y, (int)spritePos.X, (int)spritePos.Y);
            this.isEncountered = false;
        }


        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
            }
        }
        public bool IsDefeated
        {
            get
            {
                return this.isDefeated;
            }
            set
            {
                this.isDefeated = value;
            }
        }
        public Rectangle FrameRect
        {
            get
            {
                return this.frameRect;
            }
            set
            {
                this.frameRect = value;
            }
        }
        public void Update(GameTime gameTime)
        {
            //if collision - unhide;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!isHidden)
            {
                spriteBatch.Draw(this.SpriteSheet, this.FrameRect, Color.White);
            }
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

    }
}
