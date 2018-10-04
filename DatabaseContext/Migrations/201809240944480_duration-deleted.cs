namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class durationdeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exams", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "Duration", c => c.Double(nullable: false));
        }
    }
}
