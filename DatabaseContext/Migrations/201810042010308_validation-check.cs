namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationcheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
