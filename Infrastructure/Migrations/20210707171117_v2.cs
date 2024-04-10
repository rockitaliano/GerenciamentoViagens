using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Caminhao_CaminhaoId",
                table: "Viagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Motorista_MotoristaId",
                table: "Viagens");

            migrationBuilder.DropTable(
                name: "Caminhao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_CaminhaoId",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_MotoristaId",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "IdViagem",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "CaminhaoId",
                table: "Viagens");

            migrationBuilder.AddColumn<string>(
                name: "Eixos",
                schema: "dbo",
                table: "Motorista",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                schema: "dbo",
                table: "Motorista",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                schema: "dbo",
                table: "Motorista",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                schema: "dbo",
                table: "Motorista",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViagemId",
                table: "Viagens",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens",
                column: "ViagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "Eixos",
                schema: "dbo",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "Marca",
                schema: "dbo",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "Modelo",
                schema: "dbo",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "Placa",
                schema: "dbo",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "ViagemId",
                table: "Viagens");

            migrationBuilder.AddColumn<int>(
                name: "IdViagem",
                table: "Viagens",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CaminhaoId",
                table: "Viagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens",
                column: "IdViagem");

            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    CaminhaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eixos = table.Column<string>(type: "varchar(100)", nullable: true),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: true),
                    MotoristaId = table.Column<int>(type: "int", nullable: true),
                    Placa = table.Column<string>(type: "varchar(100)", nullable: true),
                    ViagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.CaminhaoId);
                    table.ForeignKey(
                        name: "FK_Caminhao_Motorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalSchema: "dbo",
                        principalTable: "Motorista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_CaminhaoId",
                table: "Viagens",
                column: "CaminhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_MotoristaId",
                table: "Viagens",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Caminhao_MotoristaId",
                table: "Caminhao",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Caminhao_CaminhaoId",
                table: "Viagens",
                column: "CaminhaoId",
                principalTable: "Caminhao",
                principalColumn: "CaminhaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Motorista_MotoristaId",
                table: "Viagens",
                column: "MotoristaId",
                principalSchema: "dbo",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}