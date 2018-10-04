namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examObtainedMarksAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "ObtainedMarks", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "ObtainedMarks");
        }
    }
}
