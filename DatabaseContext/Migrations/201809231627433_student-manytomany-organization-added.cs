namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentmanytomanyorganizationadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "Student_Id", "dbo.Students");
            DropIndex("dbo.Organizations", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentOrganizations",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Organization_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Organization_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Organization_Id);
            
            DropColumn("dbo.Organizations", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Student_Id", c => c.Int());
            DropForeignKey("dbo.StudentOrganizations", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.StudentOrganizations", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentOrganizations", new[] { "Organization_Id" });
            DropIndex("dbo.StudentOrganizations", new[] { "Student_Id" });
            DropTable("dbo.StudentOrganizations");
            CreateIndex("dbo.Organizations", "Student_Id");
            AddForeignKey("dbo.Organizations", "Student_Id", "dbo.Students", "Id");
        }
    }
}
