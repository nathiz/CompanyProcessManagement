using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyProcessManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartamentoAndSetorToArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Areas_AreaId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProcesses_Processes_ProcessId",
                table: "SubProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubProcesses",
                table: "SubProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processes",
                table: "Processes");

            migrationBuilder.RenameTable(
                name: "SubProcesses",
                newName: "Subprocessos");

            migrationBuilder.RenameTable(
                name: "Processes",
                newName: "Processos");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Areas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Areas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Subprocessos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Subprocessos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_SubProcesses_ProcessId",
                table: "Subprocessos",
                newName: "IX_Subprocessos_ProcessId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Processos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Processos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Processes_AreaId",
                table: "Processos",
                newName: "IX_Processos_AreaId");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Areas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "Areas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubProcessId",
                table: "Subprocessos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Processos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subprocessos",
                table: "Subprocessos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processos",
                table: "Processos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documentos_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ferramentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferramentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ferramentas_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ferramentas_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responsaveis_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subprocessos_SubProcessId",
                table: "Subprocessos",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProcessoId",
                table: "Documentos",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_SubProcessId",
                table: "Documentos",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_ProcessoId",
                table: "Ferramentas",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_SubProcessId",
                table: "Ferramentas",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_ProcessoId",
                table: "Responsaveis",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_SubProcessId",
                table: "Responsaveis",
                column: "SubProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Areas_AreaId",
                table: "Processos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subprocessos_Processos_ProcessId",
                table: "Subprocessos",
                column: "ProcessId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subprocessos_Subprocessos_SubProcessId",
                table: "Subprocessos",
                column: "SubProcessId",
                principalTable: "Subprocessos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Areas_AreaId",
                table: "Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Subprocessos_Processos_ProcessId",
                table: "Subprocessos");

            migrationBuilder.DropForeignKey(
                name: "FK_Subprocessos_Subprocessos_SubProcessId",
                table: "Subprocessos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Ferramentas");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subprocessos",
                table: "Subprocessos");

            migrationBuilder.DropIndex(
                name: "IX_Subprocessos_SubProcessId",
                table: "Subprocessos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processos",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Setor",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "SubProcessId",
                table: "Subprocessos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Processos");

            migrationBuilder.RenameTable(
                name: "Subprocessos",
                newName: "SubProcesses");

            migrationBuilder.RenameTable(
                name: "Processos",
                newName: "Processes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Areas",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Areas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubProcesses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "SubProcesses",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_Subprocessos_ProcessId",
                table: "SubProcesses",
                newName: "IX_SubProcesses_ProcessId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Processes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Processes",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_Processos_AreaId",
                table: "Processes",
                newName: "IX_Processes_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubProcesses",
                table: "SubProcesses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processes",
                table: "Processes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Areas_AreaId",
                table: "Processes",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProcesses_Processes_ProcessId",
                table: "SubProcesses",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
