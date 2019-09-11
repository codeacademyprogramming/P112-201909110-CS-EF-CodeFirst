namespace CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPublishDateToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PublishDate");
        }
    }
}
