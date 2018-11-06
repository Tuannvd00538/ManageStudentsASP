using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiinGroupManageStudents.Migrations
{
    public partial class SiinGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    RollNumber = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.RollNumber);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectMark = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(nullable: true),
                    StudentRollNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_Student_StudentRollNumber",
                        column: x => x.StudentRollNumber,
                        principalTable: "Student",
                        principalColumn: "RollNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FullName", "Status", "UpdatedAt" },
                values: new object[] { "D00538", new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), "admin@siingroup.com", "Ngô Văn Tuấn", 0, new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FullName", "Status", "UpdatedAt" },
                values: new object[] { "D00529", new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), "nhuconcua@gmail.com", "Phan Văn Hoàng Hưng", 0, new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FullName", "Status", "UpdatedAt" },
                values: new object[] { "D00553", new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local), "ngaccoc@gmail.com", "Nguyễn Văn Ngọc", 0, new DateTime(2018, 11, 6, 19, 37, 56, 400, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 1, "D00538", 9, "Java Core" });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 2, "D00529", 7, "C#" });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 3, "D00553", 8, "PHP" });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentRollNumber",
                table: "Mark",
                column: "StudentRollNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
