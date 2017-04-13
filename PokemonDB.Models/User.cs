namespace PokemonDB.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        //TODO: Add validation
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public virtual ICollection<Trainer> Characters { get; set; }
    }
}
