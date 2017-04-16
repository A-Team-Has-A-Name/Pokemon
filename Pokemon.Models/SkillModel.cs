namespace Pokemon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Skills")]
    public class SkillModel
    {
        public SkillModel()
        {
            this.PossibleSkillOwners = new HashSet<PokedexEntry>();
            this.CurrentSkillOwners = new HashSet<PokemonModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int PowerPoints { get; set; }
        public virtual ICollection<PokedexEntry> PossibleSkillOwners { get; set; }
        public virtual ICollection<PokemonModel> CurrentSkillOwners { get; set; }
    }
}
