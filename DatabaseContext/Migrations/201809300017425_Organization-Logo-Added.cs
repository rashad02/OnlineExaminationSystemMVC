namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationLogoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Logo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "Logo");
        }
    }
}
