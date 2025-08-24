using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD_clean_architecture.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModel = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    CarPrice = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Carcolor = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    IsSold = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
