namespace CodeFirstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "GameType");
        }
    }
}
