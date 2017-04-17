namespace Pokemon.Data
{
    using Models;
    using PokemonDB.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PokemonContext : DbContext
    {
        public PokemonContext()
            : base("name=PokemonContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PokemonContext, Configuration>());
            //.SetInitializer(new DropCreateDatabaseAlways<PokemonContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainerTeamMember>()
                .HasKey(t => t.PokemonId)
                .HasRequired(t => t.Pokemon)
                .WithOptional(p => p.TrainerTeam);

            modelBuilder.Entity<TrainerTeamMember>()
                .HasRequired(t => t.Trainer)
                .WithMany(t => t.TrainerTeamMembers);

            modelBuilder.Entity<PokemonModel>()
                .HasOptional(p => p.Trainer)
                .WithMany(t => t.CaughtPokemon);

            modelBuilder.Entity<SkillModel>()
                .HasMany(s => s.PossibleSkillOwners)
                .WithMany(p => p.PossibleSkills)
                .Map(s => 
                {
                    s.ToTable("SkillsPokedexEntries");
                    s.MapLeftKey("SkillId");
                    s.MapRightKey("PokedexEntryId");
                });

            modelBuilder.Entity<SkillModel>()
                .HasMany(s => s.CurrentSkillOwners)
                .WithMany(p => p.Skills)
                .Map(s =>
                {
                    s.ToTable("SkillsPokemon");
                    s.MapLeftKey("SkillId");
                    s.MapRightKey("PokemonId");
                });

            modelBuilder.Entity<TypeModel>()
                .HasMany(t => t.Pokemon)
                .WithMany(p => p.Types)
                .Map(t =>
                {
                    t.ToTable("TypesPokedexEntries");
                    t.MapLeftKey("TypeId");
                    t.MapRightKey("PokedexEntryId");
                });
          
        }

        public virtual DbSet<TrainerTeamMember> TrainerTeamMembers { get; set; }
        public virtual DbSet<SkillModel> Skills { get; set; }
        public virtual DbSet<PokemonModel> Pokemon { get; set; }
        public virtual DbSet<PokedexEntry> PokedexEntries { get; set; }
        public virtual DbSet<TypeModel> Types { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<TrainerModel> Trainers { get; set; }
        public virtual DbSet<AreaModel> Areas { get; set; }
        public virtual DbSet<ItemModel> Items { get; set; }
    }
}