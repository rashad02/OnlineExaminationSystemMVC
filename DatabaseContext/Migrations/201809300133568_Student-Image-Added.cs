namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentImageAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Image", c => c.Byte(nullable: false));
        }
    }
}
