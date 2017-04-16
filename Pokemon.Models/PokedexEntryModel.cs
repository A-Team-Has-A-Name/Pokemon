namespace Pokemon.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PokedexEntry
    {
        public PokedexEntry()
        {
            this.Types = new HashSet<TypeModel>();
            this.PossibleSkills = new HashSet<SkillModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseHealth { get; set; }
        public int BaseAttack { get; set; }
        public int SpriteX { get; set; }
        public int SpriteY { get; set; }
        public virtual ICollection<TypeModel> Types { get; set; }
        public virtual ICollection<SkillModel> PossibleSkills { get; set; }
    }
}
