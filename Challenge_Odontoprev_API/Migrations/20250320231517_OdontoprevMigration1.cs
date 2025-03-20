using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Odontoprev_API.Migrations
{
    /// <inheritdoc />
    public partial class OdontoprevMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SEQ_CONSULTA");

            migrationBuilder.CreateSequence(
                name: "SEQ_DENTISTA");

            migrationBuilder.CreateSequence(
                name: "SEQ_HISTORICO");

            migrationBuilder.CreateSequence(
                name: "SEQ_PACIENTE");

            migrationBuilder.AlterColumn<long>(
                name: "ID_PACIENTE",
                table: "PACIENTE",
                type: "NUMBER(19)",
                nullable: false,
                defaultValueSql: "SEQ_PACIENTE.NEXTVAL",
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_HISTORICO",
                table: "HISTORICO_CONSULTA",
                type: "NUMBER(19)",
                nullable: false,
                defaultValueSql: "SEQ_HISTORICO.NEXTVAL",
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_DENTISTA",
                table: "DENTISTA",
                type: "NUMBER(19)",
                nullable: false,
                defaultValueSql: "SEQ_DENTISTA.NEXTVAL",
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_CONSULTA",
                table: "CONSULTA",
                type: "NUMBER(19)",
                nullable: false,
                defaultValueSql: "SEQ_DENTISTA.NEXTVAL",
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SEQ_CONSULTA");

            migrationBuilder.DropSequence(
                name: "SEQ_DENTISTA");

            migrationBuilder.DropSequence(
                name: "SEQ_HISTORICO");

            migrationBuilder.DropSequence(
                name: "SEQ_PACIENTE");

            migrationBuilder.AlterColumn<long>(
                name: "ID_PACIENTE",
                table: "PACIENTE",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldDefaultValueSql: "SEQ_PACIENTE.NEXTVAL")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_HISTORICO",
                table: "HISTORICO_CONSULTA",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldDefaultValueSql: "SEQ_HISTORICO.NEXTVAL")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_DENTISTA",
                table: "DENTISTA",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldDefaultValueSql: "SEQ_DENTISTA.NEXTVAL")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "ID_CONSULTA",
                table: "CONSULTA",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldDefaultValueSql: "SEQ_DENTISTA.NEXTVAL")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }
    }
}
