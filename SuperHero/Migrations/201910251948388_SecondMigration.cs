namespace SuperHero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "primaryPower", c => c.String());
            AddColumn("dbo.Heroes", "secondaryPower", c => c.String());
            AddColumn("dbo.Heroes", "catchphrase", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "catchphrase");
            DropColumn("dbo.Heroes", "secondaryPower");
            DropColumn("dbo.Heroes", "primaryPower");
        }
    }
}
