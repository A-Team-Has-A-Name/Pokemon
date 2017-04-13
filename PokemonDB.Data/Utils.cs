using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDB.Data
{
    public static class Utils
    {
        public static void InitDB()
        {
            using (var context = new PokemonContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
