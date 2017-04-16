namespace Pokemon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pokemon")]
    public class PokemonModel
    {
        public PokemonModel()
        {
            this.Skills = new HashSet<SkillModel>();
        }
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public int PokedexEntryId { get; set; }
        public virtual PokedexEntry PokedexEntry { get; set; }
        public int? TrainerId { get; set; }
        public virtual TrainerModel Trainer { get; set; }
        public virtual ICollection<SkillModel> Skills { get; set; }
        public int TrainerTeamId { get; set; }
        public virtual TrainerTeamMember TrainerTeam { get; set; }
    }
}
