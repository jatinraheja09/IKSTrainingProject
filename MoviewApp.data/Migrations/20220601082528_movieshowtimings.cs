using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class movieshowtimings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTime");

            migrationBuilder.CreateTable(
                name: "movieShowTimeModel",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowTimeModel", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_movieShowTimeModel_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieShowTimeModel_theatreModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimeModel_MovieId",
                table: "movieShowTimeModel",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimeModel_TheatreId",
                table: "movieShowTimeModel",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowTimeModel");

            migrationBuilder.CreateTable(
                name: "MovieTime",
                columns: table => new
                {
                    MovieTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    TheatreModelTheatreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTime", x => x.MovieTimeId);
                    table.ForeignKey(
                        name: "FK_MovieTime_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTime_theatreModel_TheatreModelTheatreId",
                        column: x => x.TheatreModelTheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTime_MovieId",
                table: "MovieTime",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTime_TheatreModelTheatreId",
                table: "MovieTime",
                column: "TheatreModelTheatreId");
        }
    }
}
