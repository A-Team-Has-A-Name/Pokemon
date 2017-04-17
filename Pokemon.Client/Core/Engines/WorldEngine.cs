namespace Pokemon.Client.Core
{
    using Engines;
    using Interfaces;
    using System.Collections.Generic;

    //Engine for the World Screen
    public static class WorldEngine
    {
        private static List<IUpdatable> updatableObjects = new List<IUpdatable>();
        private static List<Interfaces.IDrawable> drawableObjects = new List<Interfaces.IDrawable>();

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

        public static void InitializeUpdatableObjects()
        {
            updatableObjects.Add(SessionEngine.Trainer);
            var session = SessionEngine.Trainer;
            
        }

        public static void InitializeDrawableObjects()
        {
            drawableObjects.Add(SessionEngine.Trainer);
        }
    }
}
