using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.PrevisaoSync.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Long",
                table: "FavoriteCities");

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldDefaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FavoriteCities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Feels_like",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Humidity",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "FavoriteCities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temp",
                table: "FavoriteCities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Feels_like",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "FavoriteCities");

            migrationBuilder.DropColumn(
                name: "Temp",
                table: "FavoriteCities");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "FavoriteCities",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "Long",
                table: "FavoriteCities",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
