namespace Pokemon.Data
{
    public static class Utils
    {
        public static void InitDB()
        {
            using (var context = new PokemonContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
