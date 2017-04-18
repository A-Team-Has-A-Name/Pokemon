using System.Threading;
using Microsoft.Xna.Framework;
using Pokemon.Client.GameObjects.Units.PlayableCharacters;
using Pokemon.Models;

namespace Pokemon.Client.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class User
    {
        public string Username { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastOnlineDate { get; set; }

        public List<Trainer> Trainers { get; set; }

        public User(UserModel model)
        {
            this.Username = model.Username;
            this.RegistrationDate = model.RegistrationDate;
            this.LastOnlineDate = model.LastOnlineDate;

            //Transition all the TrainerModel objects into Trainer objects.
            var tempTrainers = new List<Trainer>();
            foreach (var trainer in model.Trainers)
            {
                //TODO : The Vector2() should be the save point from last login
                Trainer T = new Trainer(trainer);
                tempTrainers.Add(T);
            }

            this.Trainers = tempTrainers;
        }
    }
}
