using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

///"Index": http://adresTwojejAplikacji/StolikiVMs/Index
///"Details": http://adresTwojejAplikacji/StolikiVMs/Details/{id}
///"Create": http://adresTwojejAplikacji/StolikiVMs/Create
///it": http://adresTwojejAplikacji/StolikiVMs/Edit/{id}
///"Delete": http://adresTwojejAplikacji/StolikiVMs/Delete/{id}

namespace Restauracja.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodajTabeleStolikiVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StolikiVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Ilosc_miejsc = table.Column<int>(type: "int", nullable: false),
                    Dostepnosc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StolikiVM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StolikiVM");
        }
    }
}
