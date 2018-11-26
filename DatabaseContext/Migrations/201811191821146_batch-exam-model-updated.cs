namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchexammodelupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Batch_Id", c => c.Int());
            CreateIndex("dbo.Exams", "Batch_Id");
            AddForeignKey("dbo.Exams", "Batch_Id", "dbo.Batches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Batch_Id", "dbo.Batches");
            DropIndex("dbo.Exams", new[] { "Batch_Id" });
            DropColumn("dbo.Exams", "Batch_Id");
        }
    }
}
