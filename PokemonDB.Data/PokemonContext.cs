namespace Pokemon.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PokemonContext : DbContext
    {
        public PokemonContext()
            : base("name=PokemonContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PokemonContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasMany((Pokemon p) => p.Types)
                .WithMany(t => t.Pokemon);

            modelBuilder.Entity<Pokemon>()
                .HasOptional(p => p.Trainer)
                .WithMany(t => t.CaughtPokemon);

        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<PokemonType> PokemonTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}