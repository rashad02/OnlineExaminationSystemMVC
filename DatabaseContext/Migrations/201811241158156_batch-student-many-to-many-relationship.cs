namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchstudentmanytomanyrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Batches", "Student_Id", "dbo.Students");
            DropIndex("dbo.Batches", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentBatches",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Batch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Batch_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Batches", t => t.Batch_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Batch_Id);
            
            AddColumn("dbo.Batches", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.Batches", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batches", "Student_Id", c => c.Int());
            DropForeignKey("dbo.StudentBatches", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.StudentBatches", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentBatches", new[] { "Batch_Id" });
            DropIndex("dbo.StudentBatches", new[] { "Student_Id" });
            DropColumn("dbo.Batches", "StudentId");
            DropTable("dbo.StudentBatches");
            CreateIndex("dbo.Batches", "Student_Id");
            AddForeignKey("dbo.Batches", "Student_Id", "dbo.Students", "Id");
        }
    }
}
