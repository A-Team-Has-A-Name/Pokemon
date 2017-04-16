namespace Pokemon.Models
{
    using System.Collections.Generic;
    public class PokemonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
