namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "LeadTrainer", c => c.Int(nullable: false));
            DropColumn("dbo.Trainers", "TrainerType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "TrainerType", c => c.Boolean(nullable: false));
            DropColumn("dbo.Courses", "LeadTrainer");
        }
    }
}
