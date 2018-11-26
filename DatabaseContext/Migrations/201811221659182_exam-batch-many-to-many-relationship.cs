namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exambatchmanytomanyrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "BatchId", "dbo.Batches");
            DropIndex("dbo.Exams", new[] { "BatchId" });
            CreateTable(
                "dbo.ExamsBatches",
                c => new
                    {
                        Exams_Id = c.Int(nullable: false),
                        Batch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exams_Id, t.Batch_Id })
                .ForeignKey("dbo.Exams", t => t.Exams_Id, cascadeDelete: false)
                .ForeignKey("dbo.Batches", t => t.Batch_Id, cascadeDelete: false)
                .Index(t => t.Exams_Id)
                .Index(t => t.Batch_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamsBatches", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.ExamsBatches", "Exams_Id", "dbo.Exams");
            DropIndex("dbo.ExamsBatches", new[] { "Batch_Id" });
            DropIndex("dbo.ExamsBatches", new[] { "Exams_Id" });
            DropTable("dbo.ExamsBatches");
            CreateIndex("dbo.Exams", "BatchId");
            AddForeignKey("dbo.Exams", "BatchId", "dbo.Batches", "Id", cascadeDelete: true);
        }
    }
}
