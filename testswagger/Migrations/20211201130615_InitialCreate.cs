using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirtRivalsswag.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metadatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehicleClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entryWindowStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    entryWindowEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Metadatas_MetaDataId",
                        column: x => x.MetaDataId,
                        principalTable: "Metadatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryReferenceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNF = table.Column<bool>(type: "bit", nullable: false),
                    stagetime = table.Column<double>(type: "float", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wheel = table.Column<bool>(type: "bit", nullable: false),
                    platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assist = table.Column<bool>(type: "bit", nullable: false),
                    challengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Challenges_challengeId",
                        column: x => x.challengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_MetaDataId",
                table: "Challenges",
                column: "MetaDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_challengeId",
                table: "Entries",
                column: "challengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Metadatas");
        }
    }
}
