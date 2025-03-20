using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Odontoprev_API.Migrations
{
    /// <inheritdoc />
    public partial class OdontoprevMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DENTISTA",
                columns: table => new
                {
                    ID_DENTISTA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CRO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ESPECIALIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENTISTA", x => x.ID_DENTISTA);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    ID_PACIENTE = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CARTEIRINHA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.ID_PACIENTE);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTA",
                columns: table => new
                {
                    ID_CONSULTA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA_CONSULTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_PACIENTE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID_DENTISTA = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA", x => x.ID_CONSULTA);
                    table.ForeignKey(
                        name: "FK_CONSULTA_DENTISTA_ID_DENTISTA",
                        column: x => x.ID_DENTISTA,
                        principalTable: "DENTISTA",
                        principalColumn: "ID_DENTISTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONSULTA_PACIENTE_ID_PACIENTE",
                        column: x => x.ID_PACIENTE,
                        principalTable: "PACIENTE",
                        principalColumn: "ID_PACIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_CONSULTA",
                columns: table => new
                {
                    ID_HISTORICO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_CONSULTA = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DATA_ATENDIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MOTIVO_CONSULTA = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    OBSERVACOES = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_CONSULTA", x => x.ID_HISTORICO);
                    table.ForeignKey(
                        name: "FK_HISTORICO_CONSULTA_CONSULTA_ID_CONSULTA",
                        column: x => x.ID_CONSULTA,
                        principalTable: "CONSULTA",
                        principalColumn: "ID_CONSULTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_ID_DENTISTA",
                table: "CONSULTA",
                column: "ID_DENTISTA");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_ID_PACIENTE",
                table: "CONSULTA",
                column: "ID_PACIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_CONSULTA_ID_CONSULTA",
                table: "HISTORICO_CONSULTA",
                column: "ID_CONSULTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORICO_CONSULTA");

            migrationBuilder.DropTable(
                name: "CONSULTA");

            migrationBuilder.DropTable(
                name: "DENTISTA");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
