namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultModelAdded3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultStudents",
                c => new
                    {
                        Result_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Result_Id, t.Student_Id })
                .ForeignKey("dbo.Results", t => t.Result_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Result_Id)
                .Index(t => t.Student_Id);
            
            AddColumn("dbo.Courses", "Result_Id", c => c.Int());
            AddColumn("dbo.Courses", "Results_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Result_Id");
            CreateIndex("dbo.Courses", "Results_Id");
            AddForeignKey("dbo.Courses", "Result_Id", "dbo.Results", "Id");
            AddForeignKey("dbo.Courses", "Results_Id", "dbo.Results", "Id");
            DropColumn("dbo.Results", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "StudentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Courses", "Results_Id", "dbo.Results");
            DropForeignKey("dbo.ResultStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ResultStudents", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.Courses", "Result_Id", "dbo.Results");
            DropIndex("dbo.ResultStudents", new[] { "Student_Id" });
            DropIndex("dbo.ResultStudents", new[] { "Result_Id" });
            DropIndex("dbo.Courses", new[] { "Results_Id" });
            DropIndex("dbo.Courses", new[] { "Result_Id" });
            DropColumn("dbo.Courses", "Results_Id");
            DropColumn("dbo.Courses", "Result_Id");
            DropTable("dbo.ResultStudents");
        }
    }
}
