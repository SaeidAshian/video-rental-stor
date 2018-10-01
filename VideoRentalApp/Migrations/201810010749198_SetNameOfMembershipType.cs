namespace VideoRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NameOfType = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NameOfType = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NameOfType = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NameOfType = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
