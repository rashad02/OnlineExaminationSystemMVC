namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionOrderAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionAnswers", "OptionOder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionAnswers", "OptionOder");
        }
    }
}
