namespace Pokemon.Game
{
    using Pokemon.Data;
    class Startup
    {
        static void Main(string[] args)
        {
            Utils.InitDB();
        }
    }
}
