using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDemo.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "CityCompanies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mayor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mayor_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityCompanies_CityId1",
                table: "CityCompanies",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Mayor_CityId",
                table: "Mayor",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CityCompanies_Cities_CityId1",
                table: "CityCompanies",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityCompanies_Cities_CityId1",
                table: "CityCompanies");

            migrationBuilder.DropTable(
                name: "Mayor");

            migrationBuilder.DropIndex(
                name: "IX_CityCompanies_CityId1",
                table: "CityCompanies");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "CityCompanies");
        }
    }
}
