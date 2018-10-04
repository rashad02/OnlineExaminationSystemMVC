namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organizationadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "About");
        }
    }
}
