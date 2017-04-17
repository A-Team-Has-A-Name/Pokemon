namespace PokemonDB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MappingString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Level = c.Int(nullable: false),
                        PokedexEntryId = c.Int(nullable: false),
                        TrainerId = c.Int(),
                        TrainerTeamId = c.Int(nullable: false),
                        AreaModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PokedexEntries", t => t.PokedexEntryId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .ForeignKey("dbo.Areas", t => t.AreaModel_Id)
                .Index(t => t.PokedexEntryId)
                .Index(t => t.TrainerId)
                .Index(t => t.AreaModel_Id);
            
            CreateTable(
                "dbo.PokedexEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BaseHealth = c.Int(nullable: false),
                        BaseAttack = c.Int(nullable: false),
                        SpriteX = c.Int(nullable: false),
                        SpriteY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Damage = c.Int(nullable: false),
                        PowerPoints = c.Int(nullable: false),
                        TypeModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeModel_Id)
                .Index(t => t.TypeModel_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.TrainerTeamMembers",
                c => new
                    {
                        PokemonId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonId)
                .ForeignKey("dbo.Pokemon", t => t.PokemonId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.PokemonId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        LastOnlineDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillsPokemon",
                c => new
                    {
                        SkillId = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SkillId, t.PokemonId })
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Pokemon", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "dbo.SkillsPokedexEntries",
                c => new
                    {
                        SkillId = c.Int(nullable: false),
                        PokedexEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SkillId, t.PokedexEntryId })
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.PokedexEntries", t => t.PokedexEntryId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.PokedexEntryId);
            
            CreateTable(
                "dbo.TypesPokedexEntries",
                c => new
                    {
                        TypeId = c.Int(nullable: false),
                        PokedexEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeId, t.PokedexEntryId })
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.PokedexEntries", t => t.PokedexEntryId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.PokedexEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pokemon", "AreaModel_Id", "dbo.Areas");
            DropForeignKey("dbo.Pokemon", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "UserId", "dbo.Users");
            DropForeignKey("dbo.TrainerTeamMembers", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.TrainerTeamMembers", "PokemonId", "dbo.Pokemon");
            DropForeignKey("dbo.Items", "OwnerId", "dbo.Trainers");
            DropForeignKey("dbo.Pokemon", "PokedexEntryId", "dbo.PokedexEntries");
            DropForeignKey("dbo.Skills", "TypeModel_Id", "dbo.Types");
            DropForeignKey("dbo.TypesPokedexEntries", "PokedexEntryId", "dbo.PokedexEntries");
            DropForeignKey("dbo.TypesPokedexEntries", "TypeId", "dbo.Types");
            DropForeignKey("dbo.SkillsPokedexEntries", "PokedexEntryId", "dbo.PokedexEntries");
            DropForeignKey("dbo.SkillsPokedexEntries", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillsPokemon", "PokemonId", "dbo.Pokemon");
            DropForeignKey("dbo.SkillsPokemon", "SkillId", "dbo.Skills");
            DropIndex("dbo.TypesPokedexEntries", new[] { "PokedexEntryId" });
            DropIndex("dbo.TypesPokedexEntries", new[] { "TypeId" });
            DropIndex("dbo.SkillsPokedexEntries", new[] { "PokedexEntryId" });
            DropIndex("dbo.SkillsPokedexEntries", new[] { "SkillId" });
            DropIndex("dbo.SkillsPokemon", new[] { "PokemonId" });
            DropIndex("dbo.SkillsPokemon", new[] { "SkillId" });
            DropIndex("dbo.TrainerTeamMembers", new[] { "TrainerId" });
            DropIndex("dbo.TrainerTeamMembers", new[] { "PokemonId" });
            DropIndex("dbo.Items", new[] { "OwnerId" });
            DropIndex("dbo.Trainers", new[] { "UserId" });
            DropIndex("dbo.Skills", new[] { "TypeModel_Id" });
            DropIndex("dbo.Pokemon", new[] { "AreaModel_Id" });
            DropIndex("dbo.Pokemon", new[] { "TrainerId" });
            DropIndex("dbo.Pokemon", new[] { "PokedexEntryId" });
            DropTable("dbo.TypesPokedexEntries");
            DropTable("dbo.SkillsPokedexEntries");
            DropTable("dbo.SkillsPokemon");
            DropTable("dbo.Users");
            DropTable("dbo.TrainerTeamMembers");
            DropTable("dbo.Items");
            DropTable("dbo.Trainers");
            DropTable("dbo.Types");
            DropTable("dbo.Skills");
            DropTable("dbo.PokedexEntries");
            DropTable("dbo.Pokemon");
            DropTable("dbo.Areas");
        }
    }
}
