using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDB.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpritesheetPath { get; set; }
        public int MainPokemonId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Pokemon MainPokemon { get; set; }
        public virtual ICollection<Pokemon> CaughtPokemon { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
