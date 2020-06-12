using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhattaMovie.Persistency.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    ApiSecret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tittle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movies_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieRating = table.Column<float>(nullable: true),
                    OwnerID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    MovieID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ApiKey", "ApiSecret", "Role", "Username" },
                values: new object[] { 1, "9be7824a-fd2c-4248-9c3d-a99e8a8fcdf7", "67a14938-1f89-45fc-a9f3-a6822fbfeb02", "admin", "Admin1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ApiKey", "ApiSecret", "Role", "Username" },
                values: new object[] { 2, "79b4c44f-ca85-46a8-a8e5-249d29723901", "481c44c1-b7ed-42e7-ba17-31601997d138", "admin", "Admin2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ApiKey", "ApiSecret", "Role", "Username" },
                values: new object[] { 3, "67776dad-a538-4206-8968-4ac619c4d487", "9545b98e-cc24-44c6-a9c4-6cd6507e6240", "user", "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ApiKey", "ApiSecret", "Role", "Username" },
                values: new object[] { 4, "64263dfb-e5e9-4b42-90e4-252e5360a02c", "398467dc-0875-46ad-8bdf-bccbee9dda00", "user", "User2" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_OwnerID",
                table: "Movies",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieID",
                table: "Ratings",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OwnerID",
                table: "Ratings",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieID",
                table: "Reviews",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OwnerID",
                table: "Reviews",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
