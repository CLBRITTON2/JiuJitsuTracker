using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiuJitsuTracker.Migrations
{
    public partial class AddCategoryToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeltColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassUniformType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassFocus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatTime = table.Column<int>(type: "int", nullable: false),
                    TotalMatTime = table.Column<int>(type: "int", nullable: false),
                    ClassLogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
