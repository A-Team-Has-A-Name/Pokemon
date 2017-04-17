namespace PokemonDB.Data.Migrations.Seed
{
    using Pokemon.Data;
    using Pokemon.Models;
    using System;
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

        public static void SeedSkills(PokemonContext context)
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

            var waterGun = new SkillModel()
            {
                Name = "Water Gun",
                PowerPoints = 25,
                Damage = 40,
                Type = types.Where(t => t.Name == "Water").FirstOrDefault()
            };

            var hydroPump = new SkillModel()
            {
                Name = "Hydro Pump",
                PowerPoints = 5,
                Damage = 110,
                Type = types.Where(t => t.Name == "Water").FirstOrDefault()
            };

            context.Skills.Add(ember);
            context.Skills.Add(firePunch);
            context.Skills.Add(thunderPunch);
            context.Skills.Add(thunderShock);
            context.Skills.Add(vineWhip);
            context.Skills.Add(razorLeaf);
            context.Skills.Add(pound);
            context.Skills.Add(megaPunch);
            context.Skills.Add(poisonSting);
            context.Skills.Add(acid);
            context.Skills.Add(waterGun);
            context.Skills.Add(hydroPump);

            context.SaveChanges();
        }

        public static void SeedPokedexEntires(PokemonContext context)
        {
            var skills = context.Skills.ToList();

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
            var grassPoisonSkills = skills.Where(s => s.Type.Name == "Grass" || s.Type.Name == "Water").ToList();
            foreach (var skill in grassPoisonSkills)
            {
                bulbasaur.PossibleSkills.Add(skill);
            }

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
            var fireSkills = skills.Where(s => s.Type.Name == "Fire").ToList();
            foreach (var skill in fireSkills)
            {
                charmander.PossibleSkills.Add(skill);
            }

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
            var waterSkills = skills.Where(s => s.Type.Name == "Water").ToList();
            foreach (var skill in waterSkills)
            {
                squirtle.PossibleSkills.Add(skill);
            }

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
            var electricSkills = skills.Where(s => s.Type.Name == "Electric").ToList();
            foreach (var skill in electricSkills)
            {
                pikachu.PossibleSkills.Add(skill);
            }

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

            var normalSkills = skills.Where(s => s.Type.Name == "Normal").ToList();
            foreach (var skill in normalSkills)
            {
                eevee.PossibleSkills.Add(skill);
            }


            context.PokedexEntries.Add(bulbasaur);
            context.PokedexEntries.Add(charmander);
            context.PokedexEntries.Add(squirtle);
            context.PokedexEntries.Add(pikachu);
            context.PokedexEntries.Add(eevee);

            context.SaveChanges();
        }

        public static void SeedPokemon(PokemonContext context)
        {
            var entries = context.PokedexEntries.Include("PossibleSkills").ToList();
            var squirltleEntry = entries.Where(p => p.Name == "Squirtle").FirstOrDefault();

            var squirtle1 = new PokemonModel()
            {
                Level = 3,
                PokedexEntry = squirltleEntry
            };
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(0));
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(1));

            var squirtle2 = new PokemonModel()
            {
                Level = 25,
                PokedexEntry = squirltleEntry
            };
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(0));
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(1));

            var squirtle3 = new PokemonModel()
            {
                Level = 16,
                PokedexEntry = squirltleEntry
            };
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(0));
            squirtle1.Skills.Add(squirltleEntry.PossibleSkills.ElementAt(1));

            var charmanderEntry = entries.Where(p => p.Name == "Charmander").FirstOrDefault();
            var charmander = new PokemonModel()
            {
                Level = 1,
                PokedexEntry = charmanderEntry
            };
            charmander.Skills.Add(charmanderEntry.PossibleSkills.ElementAt(0));
            charmander.Skills.Add(charmanderEntry.PossibleSkills.ElementAt(1));

            var eeveeEntry = entries.Where(p => p.Name == "Eevee").FirstOrDefault();
            var eevee = new PokemonModel()
            {
                Level = 35,
                PokedexEntry = eeveeEntry
            };
            eevee.Skills.Add(eeveeEntry.PossibleSkills.ElementAt(0));
            eevee.Skills.Add(eeveeEntry.PossibleSkills.ElementAt(1));

            var bulbasaurEntry = entries.Where(p => p.Name == "Bulbasaur").FirstOrDefault();
            var bulbasaur = new PokemonModel()
            {
                Level = 35,
                PokedexEntry = bulbasaurEntry
            };
            bulbasaur.Skills.Add(bulbasaurEntry.PossibleSkills.ElementAt(1));
            bulbasaur.Skills.Add(bulbasaurEntry.PossibleSkills.ElementAt(3));

            context.Pokemon.Add(squirtle1);
            context.Pokemon.Add(squirtle2);
            context.Pokemon.Add(squirtle3);
            context.Pokemon.Add(bulbasaur);
            context.Pokemon.Add(eevee);
            context.Pokemon.Add(charmander);

            context.SaveChanges();
        }

        public static void SeedUsers(PokemonContext context)
        {
            var user1 = new UserModel()
            {
                Username = "PokemonLover",
                Password = "pikachu",
                Email = "pikachi@abv.bg",
                RegistrationDate = new DateTime(2016, 02, 15),
                LastOnlineDate = new DateTime(2017, 01, 22)              
            };

            var user2 = new UserModel()
            {
                Username = "MaikaTi",
                Password = "1234",
                Email = "elami@kefche.com",
                RegistrationDate = new DateTime(2016, 11, 25),
                LastOnlineDate = new DateTime(2017, 03, 22)
            };

            var user3 = new UserModel()
            {
                Username = "Kamen",
                Password = "mnogogotin",
                Email = "fitnes@ejivot.kom",
                RegistrationDate = new DateTime(2017, 04, 17),
                LastOnlineDate = new DateTime(2017, 04, 16)
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            context.SaveChanges();
        }

        public static void SeedTrainers(PokemonContext context)
        {
            var users = context.Users.ToList();
            var pokemon = context.Pokemon.ToList();

            var trainer1 = new TrainerModel()
            {
                Name = "Josh",
                User = users.Where(u => u.Username == "Kamen").FirstOrDefault()                
            };
            //trainer1.CaughtPokemon.Add(pokemon.ElementAt(2));
            //trainer1.CaughtPokemon.Add(pokemon.ElementAt(4));

            var trainer2 = new TrainerModel()
            {
                Name = "Stamat",
                User = users.Where(u => u.Username == "Kamen").FirstOrDefault()
            };
            //trainer1.CaughtPokemon.Add(pokemon.ElementAt(0));

            var trainer3 = new TrainerModel()
            {
                Name = "Pearl",
                User = users.Where(u => u.Username == "PokemonLover").FirstOrDefault()
            };

            var trainer4 = new TrainerModel()
            {
                Name = "Joey",
                User = users.Where(u => u.Username == "PokemonLover").FirstOrDefault()
            };

            var trainer5 = new TrainerModel()
            {
                Name = "Mai",
                User = users.Where(u => u.Username == "PokemonLover").FirstOrDefault()
            };


            var trainer6 = new TrainerModel()
            {
                Name = "Helena",
                User = users.Where(u => u.Username == "MaikaTi").FirstOrDefault()
            };

            context.Trainers.Add(trainer1);
            context.Trainers.Add(trainer2);
            context.Trainers.Add(trainer3);
            context.Trainers.Add(trainer4);
            context.Trainers.Add(trainer5);
            context.Trainers.Add(trainer6);

            context.SaveChanges();

        }
    }
}
