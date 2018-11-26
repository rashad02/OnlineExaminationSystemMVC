namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchexamdateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "ExamDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batches", "ExamDate");
        }
    }
}
