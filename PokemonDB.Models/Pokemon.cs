using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDB.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Health { get; set; }
        public int TypeId { get; set; }
        public int Level { get; set; }
        public virtual ICollection<PokemonType> Types { get; set; }
        public int? TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }

    }
}
