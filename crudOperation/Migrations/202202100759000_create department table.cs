namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdepartmenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DepartmentModels");
        }
    }
}
