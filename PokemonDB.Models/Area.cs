namespace Pokemon.Models
{
    using System.Collections.Generic;
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MappingString { get; set; }
        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
