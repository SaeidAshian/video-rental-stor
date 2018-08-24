namespace VideoRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscribeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribToNewsletter");
        }
    }
}
