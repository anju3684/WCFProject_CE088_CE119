namespace TMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAssignedTo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "AssignedTo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "AssignedTo", c => c.Int(nullable: false));
        }
    }
}
