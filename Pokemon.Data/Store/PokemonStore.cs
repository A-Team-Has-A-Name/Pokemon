using Pokemon.Data;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDB.Data.Store
{
    public static class PokemonStore
    {
        public static List<PokemonModel> GetAllWildPokemon()
        {
            using (var context = new PokemonContext())
            {
                return context.Pokemon.Include("PokedexEntry").Include("Skills").Where(p => p.TrainerId == null).ToList();
            }
        }
    }
}
