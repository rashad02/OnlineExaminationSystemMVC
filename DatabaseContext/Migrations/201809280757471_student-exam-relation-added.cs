namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentexamrelationadded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentOrganizations", newName: "OrganizationStudents");
            DropPrimaryKey("dbo.OrganizationStudents");
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Exams_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Exams_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exams_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Exams_Id);
            
            AddPrimaryKey("dbo.OrganizationStudents", new[] { "Organization_Id", "Student_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentExams", "Exams_Id", "dbo.Exams");
            DropForeignKey("dbo.StudentExams", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentExams", new[] { "Exams_Id" });
            DropIndex("dbo.StudentExams", new[] { "Student_Id" });
            DropPrimaryKey("dbo.OrganizationStudents");
            DropTable("dbo.StudentExams");
            AddPrimaryKey("dbo.OrganizationStudents", new[] { "Student_Id", "Organization_Id" });
            RenameTable(name: "dbo.OrganizationStudents", newName: "StudentOrganizations");
        }
    }
}
