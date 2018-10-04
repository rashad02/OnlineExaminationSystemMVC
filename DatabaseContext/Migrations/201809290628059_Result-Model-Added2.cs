namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultModelAdded2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamsId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ObtainedMarks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamsId, cascadeDelete: true)
                .Index(t => t.ExamsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "ExamsId", "dbo.Exams");
            DropIndex("dbo.Results", new[] { "ExamsId" });
            DropTable("dbo.Results");
        }
    }
}
