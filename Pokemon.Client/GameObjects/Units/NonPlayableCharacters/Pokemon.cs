namespace Pokemon.Client.GameObjects.Units.NonPlayableCharacters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;
    using Textures;
    using Models;
    using System;
    using Core.Engines;

    public class Pokemon : GameObject, IUpdatable, IDamagable
    {
        private const int pokemonSpriteHeight = 100;
        private const int pokemonSpriteWidth = 100;
        private const int height = 130;
        private const int width = 130;
        private static Random random = new Random();
        private string nickname;
        public Pokemon(PokemonModel model)
        { 
            this.SpriteSheet = TextureLoader.PokemonSheet;
            this.TextureHeight = pokemonSpriteHeight;
            this.TextureWidth = pokemonSpriteWidth;

            this.Name = model.PokedexEntry.Name;           
            this.Nickname = model.Nickname;
            this.Level = model.Level;
            this.LevelUp(this.Level);
            this.Health = model.PokedexEntry.BaseHealth;
            this.Attack = model.PokedexEntry.BaseAttack;

            this.Position = this.GenerateRandomVector();   
            var spriteX = model.PokedexEntry.SpriteX;
            var spriteY = model.PokedexEntry.SpriteY;
            this.FrameRect = new Rectangle(spriteX, spriteY, pokemonSpriteWidth, pokemonSpriteHeight );
            this.BoundingBox = new Rectangle((int)this.X, (int)this.Y, width, height);
            if(model.TrainerId != null)
            {
                this.IsEncountered = true;
                this.IsHidden = false;
            }
            else
            {
                this.IsEncountered = false;
                this.IsHidden = true;
            }
            this.IsDefeated = false;
        }

        public string Name { get; set; }
        public string Nickname
        {
            get
            {
                return this.nickname;
            }
            set
            {
                if(value == null)
                {
                    value = this.Name;
                }
                this.nickname = value;
            }
        }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Level { get; set; }
        public bool IsDefeated { get; set; }
        public Rectangle FrameRect { get; set; }
        public bool IsHidden { get; set; }
        public bool IsEncountered { get; set; }


        public void Update(GameTime gameTime)
        {
            if (IsEncountered)
            {
                this.IsHidden = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {                       
            if (!IsHidden)
            {
                spriteBatch.Draw(this.SpriteSheet,this.BoundingBox, this.FrameRect, Color.White);
            }           
        }
        public Vector2 GenerateRandomVector()
        {
            int xLimit = SessionEngine.WindowWidth - this.TextureWidth + 1;
            int yLimit = SessionEngine.WindowHeight - this.TextureHeight + 1;
            int x = random.Next(0, xLimit);
            int y = random.Next(0, yLimit);

            return new Vector2(x, y);
        }

        public void LevelUp(int level)
        {
            for (int i = 0; i < level; i++)
            {
                this.Health += 15;
                this.Attack += 5;
            }
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }

    }
}
