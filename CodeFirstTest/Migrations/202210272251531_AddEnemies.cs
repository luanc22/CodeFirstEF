namespace CodeFirstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnemies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enemies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        HP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enemies");
        }
    }
}
