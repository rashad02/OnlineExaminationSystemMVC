namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trainerbatchrelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainerBatches",
                c => new
                    {
                        Trainer_Id = c.Int(nullable: false),
                        Batch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_Id, t.Batch_Id })
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Batches", t => t.Batch_Id, cascadeDelete: true)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Batch_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerBatches", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.TrainerBatches", "Trainer_Id", "dbo.Trainers");
            DropIndex("dbo.TrainerBatches", new[] { "Batch_Id" });
            DropIndex("dbo.TrainerBatches", new[] { "Trainer_Id" });
            DropTable("dbo.TrainerBatches");
        }
    }
}
