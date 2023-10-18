using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Data.Migrations
{
    /// <inheritdoc />
    public partial class Rezerwacje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StolikId = table.Column<int>(type: "int", nullable: false),
                    DataRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");
        }
    }
}
