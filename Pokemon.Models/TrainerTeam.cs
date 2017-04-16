
namespace Pokemon.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerTeamMember
    {
        [Key]
        public int PokemonId { get; set; }
        public int TrainerId { get; set; }
        public virtual TrainerModel Trainer { get; set; }
        public virtual PokemonModel Pokemon { get; set; }
        [Range(1, 6)]
        public int Position { get; set; }
    }
}
