using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImagineBeyond.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(150)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    DateOfBird = table.Column<DateTime>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateLastUpdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
