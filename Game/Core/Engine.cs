namespace Pokemon.Client.Core
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Pokemon.Client.GameObjects.Units.PlayableCharacters;
    using System.Collections.Generic;

    public static class Engine
    {
        public const int WindowHeight = 900;
        public const int WindowWidth = 1400;
        private static Trainer trainer;
        private static List<IUpdatable> updatableObjects = new List<IUpdatable>();
        private static List<Interfaces.IDrawable> drawableObjects = new List<Interfaces.IDrawable>();


        public static Trainer Trainer
        {
            get
            {
                return Engine.trainer;
            }
        }

        public static void InitializeTrainer()
        {
            Vector2 pos = new Vector2(100, 100);
            Engine.trainer = new Trainer(pos);
        }
        public static List<Interfaces.IDrawable> DrawableObjects
        {
            get
            {
                return Engine.drawableObjects;
            }
        }

        public static List<IUpdatable> UpdatableObjects
        {
            get
            {
                return Engine.updatableObjects;
            }
        }

        public static void InitializeUpdatableObjects()
        {
            updatableObjects.Add(Engine.Trainer);
            System.Console.WriteLine(updatableObjects.ToString());
        }

        public static void InitializeDrawableObjects()
        {
            drawableObjects.Add(trainer);
        }
    }
}
