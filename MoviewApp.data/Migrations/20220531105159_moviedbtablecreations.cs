using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class moviedbtablecreations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "theatreModel",
                columns: table => new
                {
                    TheatreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheatreLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheatreCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theatreModel", x => x.TheatreId);
                });

            migrationBuilder.CreateTable(
                name: "MovieTime",
                columns: table => new
                {
                    MovieTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    TheatreModelTheatreId = table.Column<int>(type: "int", nullable: true),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTime");

            migrationBuilder.DropTable(
                name: "theatreModel");
        }
    }
}
