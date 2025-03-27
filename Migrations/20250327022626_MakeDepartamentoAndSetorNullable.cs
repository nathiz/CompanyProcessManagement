using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProcessManagement.Migrations
{
    /// <inheritdoc />
    public partial class MakeDepartamentoAndSetorNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Areas",
                nullable: true,  // Permitir null
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "Areas",
                nullable: true,  // Permitir null
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Areas",
                type: "text",
                nullable: false,  // Tornar como NOT NULL
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Setor",
                table: "Areas",
                type: "text",
                nullable: false,  // Tornar como NOT NULL
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}