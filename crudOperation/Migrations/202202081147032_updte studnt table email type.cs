﻿namespace crudOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updtestudnttableemailtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.Int(nullable: false));
        }
    }
}
