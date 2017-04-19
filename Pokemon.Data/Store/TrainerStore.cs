namespace PokemonDB.Data.Store
{
    using Pokemon.Data;
    using Pokemon.Models;
    using System.Data.Entity;
    using System.Linq;

    public static class TrainerStore
    {    
        public static TrainerModel GetTrainerById(int id)
        {
            using (var context = new PokemonContext())
            {
                var trainer = context.Trainers.Include("CaughtPokemon").Where(t => t.Id == id).FirstOrDefault();
                return trainer;
            }
        }

        public static void UpdateTrainer(TrainerModel trainer)
        {
            using (var context = new PokemonContext())
            {
                context.Trainers.Attach(trainer);
                context.Entry(trainer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
