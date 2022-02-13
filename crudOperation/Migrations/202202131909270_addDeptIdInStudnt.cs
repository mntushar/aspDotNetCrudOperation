namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeptIdInStudnt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentModels", "Department_Id", "dbo.DepartmentModels");
            DropIndex("dbo.StudentModels", new[] { "Department_Id" });
            RenameColumn(table: "dbo.StudentModels", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.StudentModels", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentModels", "DepartmentId");
            AddForeignKey("dbo.StudentModels", "DepartmentId", "dbo.DepartmentModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModels", "DepartmentId", "dbo.DepartmentModels");
            DropIndex("dbo.StudentModels", new[] { "DepartmentId" });
            AlterColumn("dbo.StudentModels", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.StudentModels", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.StudentModels", "Department_Id");
            AddForeignKey("dbo.StudentModels", "Department_Id", "dbo.DepartmentModels", "Id");
        }
    }
}
