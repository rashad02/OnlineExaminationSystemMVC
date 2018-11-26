namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratedatetimetodatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
