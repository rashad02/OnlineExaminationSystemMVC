namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationcheck2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Image");
        }
    }
}
