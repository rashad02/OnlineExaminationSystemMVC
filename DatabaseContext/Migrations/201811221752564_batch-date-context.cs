namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchdatecontext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "ExamDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Batches", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Batches", "ExamDate", c => c.DateTime(nullable: false));
        }
    }
}
