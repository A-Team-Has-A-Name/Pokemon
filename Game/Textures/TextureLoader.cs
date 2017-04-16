﻿namespace Pokemon.Client.Textures
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    public static class TextureLoader
    {
        public static Texture2D TrainerSheet { get; private set; }
        public static Texture2D PokemonSheet { get; private set; }
        public static void Load(ContentManager content)
        {
            TrainerSheet = content.Load<Texture2D>("Sprites/RedTrainer_96x96");
            PokemonSheet = content.Load<Texture2D>("Sprites/Pokemon_80x80");
        }
    }
}