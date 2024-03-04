using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDespesas.Migrations
{
    public partial class DespesasForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrosDespesas_Despesa_DespesaId",
                table: "registrosDespesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registrosDespesas",
                table: "registrosDespesas");

            migrationBuilder.RenameTable(
                name: "registrosDespesas",
                newName: "RegistrosDespesas");

            migrationBuilder.RenameIndex(
                name: "IX_registrosDespesas_DespesaId",
                table: "RegistrosDespesas",
                newName: "IX_RegistrosDespesas_DespesaId");

            migrationBuilder.AlterColumn<int>(
                name: "DespesaId",
                table: "RegistrosDespesas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosDespesas",
                table: "RegistrosDespesas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosDespesas_Despesa_DespesaId",
                table: "RegistrosDespesas",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosDespesas_Despesa_DespesaId",
                table: "RegistrosDespesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosDespesas",
                table: "RegistrosDespesas");

            migrationBuilder.RenameTable(
                name: "RegistrosDespesas",
                newName: "registrosDespesas");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosDespesas_DespesaId",
                table: "registrosDespesas",
                newName: "IX_registrosDespesas_DespesaId");

            migrationBuilder.AlterColumn<int>(
                name: "DespesaId",
                table: "registrosDespesas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_registrosDespesas",
                table: "registrosDespesas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_registrosDespesas_Despesa_DespesaId",
                table: "registrosDespesas",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
