namespace TMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        Description = c.String(),
                        AssignedTo = c.Int(nullable: false),
                        LastDate = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Priority = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
        }
    }
}
