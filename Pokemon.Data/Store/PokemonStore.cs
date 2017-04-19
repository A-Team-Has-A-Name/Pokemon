namespace PokemonDB.Data.Store
{
    using Pokemon.Data;
    using Pokemon.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                    if (!context.ChangeTracker.Entries<PokemonModel>().Any(e => e.Entity.Id == p.Id))
                    {
                        var pokedexEntry = context.Entry(p.PokedexEntry);
                        pokedexEntry.State = EntityState.Unchanged;
                        context.Pokemon.Attach(p);
                        var entry = context.Entry(p);
                        entry.Property(e => e.TrainerId).IsModified = true;
                        entry.Property(e => e.Nickname).IsModified = true;
                        entry.Property(e => e.PokedexEntryId).IsModified = false;

                    }
                }
                    context.SaveChanges();
            }
        }

        public static PokemonModel GetPokemonById(int id)
        {
            using (var context = new PokemonContext())
            {
                return context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public static ICollection<PokemonModel> GetTrainerCaughtPokemon(int trainerId)
        {
            using (var context = new PokemonContext())
            {
                return context.Pokemon.Where(p => p.TrainerId == trainerId).Include(p => p.PokedexEntry).ToList();
            }
        }
    }
}
