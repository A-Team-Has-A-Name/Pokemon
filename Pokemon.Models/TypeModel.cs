namespace Pokemon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Types")]
    public class TypeModel
    {
        public TypeModel()
        {
            this.Pokemon = new HashSet<PokedexEntry>();
            this.Skills = new HashSet<SkillModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PokedexEntry> Pokemon { get; set; }
        public virtual ICollection<SkillModel> Skills { get; set; }
    }
}
