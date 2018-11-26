namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leadtrainerpropertytobatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "LeadTrainer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batches", "LeadTrainer");
        }
    }
}
