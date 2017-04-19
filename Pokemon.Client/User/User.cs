using System.Threading;
using Microsoft.Xna.Framework;
using Pokemon.Client.Core.Engines;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;
using Pokemon.Models;
using PokemonDB.Data.Store;

namespace Pokemon.Client.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class User
    {
        public string Username { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastOnlineDate { get; set; }

        public List<Trainer> Trainers { get; set; }

        public int Id { get; set; }

        private string Password { get; set; }


        public User(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public User(UserModel model)
        {
            this.Id = model.Id;
            this.Username = model.Username;
            this.RegistrationDate = model.RegistrationDate;
            this.LastOnlineDate = model.LastOnlineDate;

            //Transition all the TrainerModel objects into Trainer objects.
            var tempTrainers = new List<Trainer>();
            var trainers = TrainerStore.GetUserTrainers(model.Id);
            foreach (var trainer in trainers)
            {
                //TODO : The Vector2() should be the save point from last login
                Trainer T = new Trainer(trainer);
                tempTrainers.Add(T);
            }

            this.Trainers = tempTrainers;
        }
    }
}
