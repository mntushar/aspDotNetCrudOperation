namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredInStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.StudentModels", "RegNo", c => c.String(nullable: false));
            AlterColumn("dbo.StudentModels", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentModels", "Email", c => c.String());
            AlterColumn("dbo.StudentModels", "RegNo", c => c.String());
            AlterColumn("dbo.StudentModels", "Name", c => c.String());
        }
    }
}
