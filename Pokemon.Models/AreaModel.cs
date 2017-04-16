namespace Pokemon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Areas")]
    public class AreaModel
    {
        public AreaModel()
        {
            this.Pokemon = new HashSet<PokemonModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MappingString { get; set; }
        public virtual ICollection<PokemonModel> Pokemon { get; set; }
    }
}
