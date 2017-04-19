namespace Pokemon.Client.Core
{
    using Engines;
    using Interfaces;
    using GameObjects.Units.NonPlayableCharacters;
    using System.Collections.Generic;
    using PokemonDB.Data.Store;
    using Textures;
    using Microsoft.Xna.Framework.Graphics;
    using UI_Elements.Windows;
    using UI_Elements.Notifications;

    //Engine for the World Screen
    public static class WorldEngine
    {
        public static WindowManager WindowManager = new WindowManager();
        public static NotificationManager NotificationManager = new NotificationManager();
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
            updatableObjects.Add(SessionEngine.Trainer);      
                  
            foreach (var p in WorldEngine.WildPokemon)
            {
                updatableObjects.Add(p);
            }

        }

        public static void InitializeDrawableObjects()
        {
            drawableObjects.Add(SessionEngine.Trainer);

            foreach (var p in WorldEngine.WildPokemon)
            {
                drawableObjects.Add(p);
            }

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
