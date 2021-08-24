namespace CodeFirstEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMToMRelationBetweenStudentTableAndCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId })
                .ForeignKey("dbo.Students", t => t.StudentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRefId)
                .Index(t => t.CourseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students");
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropTable("dbo.StudentCourse");
        }
    }
}
