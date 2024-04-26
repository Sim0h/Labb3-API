using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestID);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestID",
                        column: x => x.PersonInterestID,
                        principalTable: "PersonInterests",
                        principalColumn: "PersonInterestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 100, "Playing video games", "Gaming" },
                    { 101, "Any type of exercise like running, sports or gym", "Exercise" },
                    { 102, "Reading books", "Reading" },
                    { 103, "Following the different football leauges in Europe", "Football" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "FirstName", "LastName", "PhoneNum" },
                values: new object[,]
                {
                    { 1, "Noah", "Testing", "1234567" },
                    { 2, "Simon", "Zooming", "1234567" },
                    { 3, "Casper", "Flyson", "1234567" },
                    { 4, "Svante", "Svensson", "1234567" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestID", "InterestID", "PersonID" },
                values: new object[,]
                {
                    { 1, 100, 1 },
                    { 2, 102, 2 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkID", "PersonInterestID", "Url" },
                values: new object[,]
                {
                    { 50, 1, "www.youtube.com" },
                    { 51, 1, "www.transfermarkt.com" },
                    { 52, 2, "www.books.com" },
                    { 53, 2, "www.running.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestID",
                table: "Links",
                column: "PersonInterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
