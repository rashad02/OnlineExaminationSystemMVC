namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchexammodelupdated2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "Batch_Id", "dbo.Batches");
            DropIndex("dbo.Exams", new[] { "Batch_Id" });
            RenameColumn(table: "dbo.Exams", name: "Batch_Id", newName: "BatchId");
            AlterColumn("dbo.Exams", "BatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exams", "BatchId");
            AddForeignKey("dbo.Exams", "BatchId", "dbo.Batches", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "BatchId", "dbo.Batches");
            DropIndex("dbo.Exams", new[] { "BatchId" });
            AlterColumn("dbo.Exams", "BatchId", c => c.Int());
            RenameColumn(table: "dbo.Exams", name: "BatchId", newName: "Batch_Id");
            CreateIndex("dbo.Exams", "Batch_Id");
            AddForeignKey("dbo.Exams", "Batch_Id", "dbo.Batches", "Id");
        }
    }
}
