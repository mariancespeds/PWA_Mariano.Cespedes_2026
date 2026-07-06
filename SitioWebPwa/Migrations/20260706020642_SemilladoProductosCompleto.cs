using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SitioWebPwa.Migrations
{
    /// <inheritdoc />
    public partial class SemilladoProductosCompleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "CodigoProducto", "Cantidad", "Detalle", "Imagen", "NombreProducto", "Precio" },
                values: new object[,]
                {
                    { 1, 0, "Camiseta titular de juego unisex", "/img/CamisetaTitularDeca.png", "Camiseta Titular", 50000.0 },
                    { 2, 0, "Camiseta Suplente de juego unisex", "/img/CamisetaSuplenteDeca.png", "Camiseta Suplente", 50000.0 },
                    { 3, 0, "Short titular de juego unisex", "/img/ShortTitularDeca.png", "Short Titular", 25000.0 },
                    { 4, 0, "Short suplente Camiseta titular de juego unisex", "/img/ShortSuplenteDeca.png", "Short Suplente", 25000.0 },
                    { 5, 0, "Termo y Mate del violeta", "/img/KitMateroDeca.png", "Kit Matero", 65000.0 },
                    { 6, 0, "Buzo DCVD", "/img/BuzoDeca.png", "Buzo Decaño", 80000.0 },
                    { 7, 0, "Piluso Vamos Violeta", "/img/PilusoDeca.png", "Piluso", 20000.0 },
                    { 8, 0, "Medias de futbol DCVD", "/img/MediasDeca.png", "Medias de futbol", 10000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
