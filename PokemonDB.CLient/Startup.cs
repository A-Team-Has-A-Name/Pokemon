
namespace PokemonDB.CLient
{
    using PokemonDB.Data;
    class Startup
    {
        static void Main(string[] args)
        {
            Utils.InitDB();
        }
    }
}
