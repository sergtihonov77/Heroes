namespace Heroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "UserName");
        }
    }
}
