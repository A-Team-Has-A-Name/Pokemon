namespace PokemonDB.Data.Migrations.Seed
{
    using Pokemon.Data;
    using Pokemon.Models;
    using System.Linq;

    public static class SeedManager
    {
        public static void SeedTypes(PokemonContext context)
        {
            var electric = new TypeModel()
            {
                Name = "Electric"
            };

            var grass = new TypeModel()
            {
                Name = "Grass"
            };

            var fire = new TypeModel()
            {
                Name = "Fire"
            };

            var poison = new TypeModel()
            {
                Name = "Poison"
            };

            var water = new TypeModel()
            {
                Name = "Water"
            };

            var normal = new TypeModel()
            {
                Name = "Normal"
            };

            context.Types.Add(electric);
            context.Types.Add(grass);
            context.Types.Add(poison);
            context.Types.Add(normal);
            context.Types.Add(water);
            context.Types.Add(fire);

            //TODO: add to types list
            context.SaveChanges();
        }

        public static void SeedPokedexEntires(PokemonContext context)
        {
            var bulbasaur = new PokedexEntry()
            {
                Name = "Bulbasaur",
                Number = 1,
                BaseHealth = 45,
                BaseAttack = 49,
                SpriteX = 0,
                SpriteY = 0,
            };
            var grassPoison = context.Types.Where(t => t.Name == "Grass" || t.Name == "Poison").ToArray();
            bulbasaur.Types.Add(grassPoison[0]);
            bulbasaur.Types.Add(grassPoison[1]);

            var charmander = new PokedexEntry()
            {
                Name = "Charmander",
                Number = 4,
                BaseHealth = 39,
                BaseAttack = 52,
                SpriteX = 3 * 80,
                SpriteY = 0
            };
            var fire = context.Types.Where(t => t.Name == "Fire").FirstOrDefault();
            charmander.Types.Add(fire);

            var squirtle = new PokedexEntry()
            {
                Name = "Squirtle",
                Number = 7,
                BaseHealth = 44,
                BaseAttack = 48,
                SpriteX = 6 * 80,
                SpriteY = 0
            };
            var water = context.Types.Where(t => t.Name == "Water").FirstOrDefault();
            squirtle.Types.Add(water);

            var pikachu = new PokedexEntry()
            {
                Name = "Pikachu",
                Number = 25,
                BaseHealth = 35,
                BaseAttack = 55,
                SpriteX = 24 * 80,
                SpriteY = 0
            };
            var electric = context.Types.Where(t => t.Name == "Electric").FirstOrDefault();
            pikachu.Types.Add(electric);

            var eevee = new PokedexEntry()
            {
                Name = "Eevee",
                Number = 133,
                BaseHealth = 55,
                BaseAttack = 55,
                SpriteX = 20 * 80,
                SpriteY = 4 * 80
            };
            var normal = context.Types.Where(t => t.Name == "Normal").FirstOrDefault();
            eevee.Types.Add(normal);

            context.PokedexEntries.Add(bulbasaur);
            context.PokedexEntries.Add(charmander);
            context.PokedexEntries.Add(squirtle);
            context.PokedexEntries.Add(pikachu);
            context.PokedexEntries.Add(eevee);

            context.SaveChanges();
        }

        private static void SeedSkills(PokemonContext context)
        {
            var types = context.Types.ToList();

            var ember = new SkillModel()
            {
                Name = "Ember",
                PowerPoints = 25,
                Damage = 40,
                Type = types.Where(t => t.Name == "Fire").FirstOrDefault()
            };

            var firePunch = new SkillModel()
            {
                Name = "Fire Punch",
                PowerPoints = 15,
                Damage = 75,
                Type = types.Where(t => t.Name == "Fire").FirstOrDefault()
            };

            var thunderPunch = new SkillModel()
            {
                Name = "Thunder Punch",
                PowerPoints = 15,
                Damage = 75,
                Type = types.Where(t => t.Name == "Electric").FirstOrDefault()
            };

            var thunderShock = new SkillModel()
            {
                Name = "Thunder Shock",
                PowerPoints = 30,
                Damage = 40,
                Type = types.Where(t => t.Name == "Electric").FirstOrDefault()
            };

            var vineWhip = new SkillModel()
            {
                Name = "Vine Whip",
                PowerPoints = 25,
                Damage = 45,
                Type = types.Where(t => t.Name == "Grass").FirstOrDefault()
            };

            var razorLeaf = new SkillModel()
            {
                Name = "RazorLeaf",
                PowerPoints = 25,
                Damage = 55,
                Type = types.Where(t => t.Name == "Grass").FirstOrDefault()
            };

            var pound = new SkillModel()
            {
                Name = "Pound",
                PowerPoints = 35,
                Damage = 40,
                Type = types.Where(t => t.Name == "Normal").FirstOrDefault()
            };

            var megaPunch = new SkillModel()
            {
                Name = "Mega Punch",
                PowerPoints = 20,
                Damage = 80,
                Type = types.Where(t => t.Name == "Normal").FirstOrDefault()
            };

            var poisonSting = new SkillModel()
            {
                Name = "Poison Sting",
                PowerPoints = 25,
                Damage = 40,
                Type = types.Where(t => t.Name == "Poison").FirstOrDefault()
            };

            var acid = new SkillModel()
            {
                Name = "Acid",
                PowerPoints = 25,
                Damage = 40,
                Type = types.Where(t => t.Name == "Poison").FirstOrDefault()
            };


        }

        private static void SeedPokemon(PokemonContext context)
        {
            var squirltleEntry = context.PokedexEntries.Where(p => p.Name == "Squirtle").FirstOrDefault();

            var squirtle1 = new PokemonModel()
            {
                Level = 3,
                PokedexEntry = squirltleEntry,
                
            };
        }
    }
}
