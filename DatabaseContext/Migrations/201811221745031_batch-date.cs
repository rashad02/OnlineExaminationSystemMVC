namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
