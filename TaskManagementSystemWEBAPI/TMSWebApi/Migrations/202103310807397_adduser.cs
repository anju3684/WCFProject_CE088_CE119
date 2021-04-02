namespace TMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "name");
        }
    }
}
