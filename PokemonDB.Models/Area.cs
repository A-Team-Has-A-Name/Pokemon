using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDB.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MappingString { get; set; }
        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
