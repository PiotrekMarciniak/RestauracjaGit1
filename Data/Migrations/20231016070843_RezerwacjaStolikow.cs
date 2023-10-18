using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Data.Migrations
{
    /// <inheritdoc />
    public partial class RezerwacjaStolikow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RezerwacjeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieINazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StolikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezerwacjeVM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezerwacjeVM");
        }
    }
}
