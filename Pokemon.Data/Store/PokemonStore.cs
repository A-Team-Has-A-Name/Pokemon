using Pokemon.Data;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void UpdatePokemon(List<PokemonModel> pokemon)
        {
            using (var context = new PokemonContext())
            {
                foreach (var p in pokemon)
                {
                    context.Pokemon.Attach(p);
                    context.Entry(p).State = EntityState.Modified;
                }
                    context.SaveChanges();
            }
        }
    }
}
