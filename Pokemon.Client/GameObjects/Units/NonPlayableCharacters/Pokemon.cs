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
        private static Random random = new Random();
        private string nickname;
        private PokemonModel model;    

        public Pokemon(PokemonModel model)
        {
            this.model = model;
            this.Id = model.Id;
            this.TrainerId = model.TrainerId;
            this.SpriteSheet = TextureLoader.PokemonSheet;
            this.TextureHeight = pokemonSpriteHeight;
            this.TextureWidth = pokemonSpriteWidth;

           // this.Name = model.PokedexEntry.Name;           
            this.Nickname = model.Nickname;
            this.Level = model.Level;
            this.LevelUp(this.Level);
            //this.Health = model.PokedexEntry.BaseHealth;
            //this.Attack = model.PokedexEntry.BaseAttack;

            this.Position = this.GenerateRandomVector();   
            //var spriteX = model.PokedexEntry.SpriteX;
            //var spriteY = model.PokedexEntry.SpriteY;
            //this.FrameRect = new Rectangle(spriteX, spriteY, this.TextureWidth, this.TextureHeight );
            this.BoundingBox = new Rectangle((int)this.X + 30, (int)this.Y + 30, this.TextureWidth - 50, this.TextureHeight - 50);

            if (model.TrainerId != null)
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

        public static bool IsCaught()
        {
            int n = random.Next(0, 2);
            return n == 1;
        }

        public int Id { get; set; }
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
        public int? TrainerId { get; set; }

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
                spriteBatch.Draw(this.SpriteSheet, new Rectangle((int)this.X, (int)this.Y, this.TextureWidth, this.TextureHeight), this.FrameRect, Color.White);
                //Draw bounding box for debugging
                //this.DrawBB(spriteBatch);
            }           
        }

        private void DrawBB(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.TheOnePixel, this.BoundingBox, Color.Red);
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

        public PokemonModel GetCurrentModelState()
        {
            this.model.TrainerId = this.TrainerId;
            return this.model;
        }
    }
}
