namespace Pokemon.Client.User
{
    using GameObjects.Units.PlayableCharacters;
    using System;
    using System.Collections.Generic;

    public class User
    {
        public string Username { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastOnlineDate { get; set; }

        public List<Trainer> Trainers { get; set; }

        //{
        //    //Transition all the TrainerModel objects into Trainer objects.
        //    var tempTrainers = new List<Trainer>();
        //    {
        //        //TODO : The Vector2() should be the save point from last login
        //        tempTrainers.Add(T);
        //    }
        //
        //    this.Trainers = tempTrainers;
        //}
    }
}
