namespace CodeFirstEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToManyRelationCourseAndAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "AuthorId");
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Author_Id");
            AddForeignKey("dbo.Courses", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
