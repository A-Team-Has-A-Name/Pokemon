namespace Pokemon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Trainers")]
    public class TrainerModel
    {
        public TrainerModel()
        {
            this.TrainerTeamMembers = new HashSet<TrainerTeamMember>();
            this.CaughtPokemon = new HashSet<PokemonModel>();
            this.Items = new HashSet<ItemModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<TrainerTeamMember> TrainerTeamMembers { get; set; }
        public virtual ICollection<PokemonModel> CaughtPokemon { get; set; }
        public virtual ICollection<ItemModel> Items { get; set; }
    }
}
