namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredInDevelopmen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DepartmentModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DepartmentModels", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DepartmentModels", "Code", c => c.String());
            AlterColumn("dbo.DepartmentModels", "Name", c => c.String());
        }
    }
}
