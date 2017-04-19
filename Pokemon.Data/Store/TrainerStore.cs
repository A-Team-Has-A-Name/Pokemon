using System.Collections;
using System.Collections.Generic;

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

        public static void RegisterTrainer(string name, int userId)
        {
            using (var context = new PokemonContext())
            {
                TrainerModel trainer = new TrainerModel();
                trainer.Name = name;
                trainer.UserId = userId;

                context.Trainers.Add(trainer);
                context.SaveChanges();
            }
        }

        public static ICollection<TrainerModel> GetUserTrainers(int id)
        {
            using (var context = new PokemonContext())
            {
                ICollection<TrainerModel> trainers = context.Trainers.Where(tr => tr.UserId == id).ToList();
                return trainers;
            }
        }

        public static void DeleteTrainer ( int id )
        {
            using ( var context = new PokemonContext ( ) )
            {
                TrainerModel trainer = context.Trainers.Where(tr => tr.Id == id).ToList().FirstOrDefault();
                context.Trainers.Remove(trainer);
                context.SaveChanges();
            }
        }
        

    }
}
