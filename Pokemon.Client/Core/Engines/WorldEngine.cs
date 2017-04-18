namespace Pokemon.Client.Core
{
    using Engines;
    using Interfaces;
    using GameObjects.Units.NonPlayableCharacters;
    using System.Collections.Generic;
    using PokemonDB.Data.Store;
    using Textures;
    using Microsoft.Xna.Framework.Graphics;

    //Engine for the World Screen
    public static class WorldEngine
    {
        public static Texture2D background = TextureLoader.WorldBackground;
        private static List<IUpdatable> updatableObjects = new List<IUpdatable>();
        private static List<Interfaces.IDrawable> drawableObjects = new List<Interfaces.IDrawable>();
        private static List<Pokemon> wildPokemon = new List<Pokemon>();
        public static List<Interfaces.IDrawable> DrawableObjects
        {
            get
            {
                return WorldEngine.drawableObjects;
            }
        }
        public static List<IUpdatable> UpdatableObjects
        {
            get
            {
                return WorldEngine.updatableObjects;
            }
        }
        public static List<Pokemon> WildPokemon
        {
            get { return WorldEngine.wildPokemon; }
        }


        public static void InitializeUpdatableObjects()
        {
            foreach (var p in WorldEngine.WildPokemon)
            {
                updatableObjects.Add(p);
            }

            updatableObjects.Add(SessionEngine.Trainer);            
        }

        public static void InitializeDrawableObjects()
        {
            foreach (var p in WorldEngine.WildPokemon)
            {
                drawableObjects.Add(p);
            }

            drawableObjects.Add(SessionEngine.Trainer);
        }

        public static void PopulateWildPokemon()
        {
            var pokemon = PokemonStore.GetAllWildPokemon();

            foreach (var p in pokemon)
            {
                var currentPokemon = new Pokemon(p);
                WildPokemon.Add(currentPokemon);
            }
        }
    }
}
