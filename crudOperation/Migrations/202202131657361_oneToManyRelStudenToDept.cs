namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneToManyRelStudenToDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentModels", "Department_Id", c => c.Int());
            CreateIndex("dbo.StudentModels", "Department_Id");
            AddForeignKey("dbo.StudentModels", "Department_Id", "dbo.DepartmentModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModels", "Department_Id", "dbo.DepartmentModels");
            DropIndex("dbo.StudentModels", new[] { "Department_Id" });
            DropColumn("dbo.StudentModels", "Department_Id");
        }
    }
}
