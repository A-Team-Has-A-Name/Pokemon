namespace Pokemon.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Characters = new HashSet<TrainerModel>();
        }
        //TODO: Add validation
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public virtual ICollection<TrainerModel> Characters { get; set; }
    }
}
