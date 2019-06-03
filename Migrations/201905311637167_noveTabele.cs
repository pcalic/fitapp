namespace FitnessApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noveTabele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clanska_Karta",
                c => new
                    {
                        ClanskaKartaId = c.Int(nullable: false, identity: true),
                        Cena = c.Decimal(precision: 18, scale: 2),
                        DatumUplate = c.DateTime(storeType: "date"),
                        DatumVazenja = c.DateTime(storeType: "date"),
                        BrojKarte = c.Int(),
                        KlijentId = c.Int(),
                    })
                .PrimaryKey(t => t.ClanskaKartaId)
                .ForeignKey("dbo.Klijent", t => t.KlijentId)
                .Index(t => t.KlijentId);
            
            CreateTable(
                "dbo.Klijent",
                c => new
                    {
                        KlijentId = c.Int(nullable: false, identity: true),
                        Ime = c.String(maxLength: 255),
                        Prezime = c.String(maxLength: 255),
                        Pol = c.String(maxLength: 1),
                        Godine = c.Int(),
                    })
                .PrimaryKey(t => t.KlijentId);
            
            CreateTable(
                "dbo.klijent_trener",
                c => new
                    {
                        KlijentId = c.Int(nullable: false),
                        TrenerId = c.Int(nullable: false),
                        OpisTreninga = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.KlijentId, t.TrenerId })
                .ForeignKey("dbo.Klijent", t => t.KlijentId, cascadeDelete: true)
                .ForeignKey("dbo.Trener", t => t.TrenerId, cascadeDelete: true)
                .Index(t => t.KlijentId)
                .Index(t => t.TrenerId);
            
            CreateTable(
                "dbo.Trener",
                c => new
                    {
                        TrenerId = c.Int(nullable: false, identity: true),
                        Ime = c.String(maxLength: 255),
                        Prezime = c.String(maxLength: 255),
                        Pol = c.String(maxLength: 1),
                        Godine = c.Int(),
                    })
                .PrimaryKey(t => t.TrenerId);
            
            CreateTable(
                "dbo.Program_Ishrane",
                c => new
                    {
                        ProgramIshraneId = c.Int(nullable: false, identity: true),
                        CenaPrograma = c.Decimal(precision: 18, scale: 2),
                        OpisPrograma = c.String(maxLength: 1),
                        KlijentId = c.Int(),
                    })
                .PrimaryKey(t => t.ProgramIshraneId)
                .ForeignKey("dbo.Klijent", t => t.KlijentId)
                .Index(t => t.KlijentId);
            
            CreateTable(
                "dbo.Proizvod",
                c => new
                    {
                        ProizvodId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 255),
                        Cena = c.Decimal(precision: 18, scale: 2),
                        Opis = c.String(maxLength: 255),
                        Vrsta = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProizvodId);
            
            CreateTable(
                "dbo.ProizvodProgram_Ishrane",
                c => new
                    {
                        Proizvod_ProizvodId = c.Int(nullable: false),
                        Program_Ishrane_ProgramIshraneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Proizvod_ProizvodId, t.Program_Ishrane_ProgramIshraneId })
                .ForeignKey("dbo.Proizvod", t => t.Proizvod_ProizvodId, cascadeDelete: true)
                .ForeignKey("dbo.Program_Ishrane", t => t.Program_Ishrane_ProgramIshraneId, cascadeDelete: true)
                .Index(t => t.Proizvod_ProizvodId)
                .Index(t => t.Program_Ishrane_ProgramIshraneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProizvodProgram_Ishrane", "Program_Ishrane_ProgramIshraneId", "dbo.Program_Ishrane");
            DropForeignKey("dbo.ProizvodProgram_Ishrane", "Proizvod_ProizvodId", "dbo.Proizvod");
            DropForeignKey("dbo.Program_Ishrane", "KlijentId", "dbo.Klijent");
            DropForeignKey("dbo.klijent_trener", "TrenerId", "dbo.Trener");
            DropForeignKey("dbo.klijent_trener", "KlijentId", "dbo.Klijent");
            DropForeignKey("dbo.Clanska_Karta", "KlijentId", "dbo.Klijent");
            DropIndex("dbo.ProizvodProgram_Ishrane", new[] { "Program_Ishrane_ProgramIshraneId" });
            DropIndex("dbo.ProizvodProgram_Ishrane", new[] { "Proizvod_ProizvodId" });
            DropIndex("dbo.Program_Ishrane", new[] { "KlijentId" });
            DropIndex("dbo.klijent_trener", new[] { "TrenerId" });
            DropIndex("dbo.klijent_trener", new[] { "KlijentId" });
            DropIndex("dbo.Clanska_Karta", new[] { "KlijentId" });
            DropTable("dbo.ProizvodProgram_Ishrane");
            DropTable("dbo.Proizvod");
            DropTable("dbo.Program_Ishrane");
            DropTable("dbo.Trener");
            DropTable("dbo.klijent_trener");
            DropTable("dbo.Klijent");
            DropTable("dbo.Clanska_Karta");
        }
    }
}
