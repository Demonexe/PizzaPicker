using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _148103_148214.PizzaPicker.DAO.Migrations
{
    public partial class Refactor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dough",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dough",
                table: "Pizzas");
        }
    }
}
