namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class durationupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "Duration");
        }
    }
}
