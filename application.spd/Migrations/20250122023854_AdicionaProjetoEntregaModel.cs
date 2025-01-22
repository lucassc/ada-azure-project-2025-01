using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.spd.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaProjetoEntregaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjetoEntregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlDoRepositorio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoEntregas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProjetoEntregas",
                columns: ["Id", "NomeDoAluno", "UrlDoRepositorio"],
                values: [1, "para alterar execute -> UPDATE [dbo].[ProjetoEntregas] SET NomeDoAluno='<seu-nome-completo-aqui>' WHERE Id = 1;", "para alterar execute -> UPDATE [dbo].[ProjetoEntregas] SET UrlDoRepositorio='<url-do-seu-projeto-aqui>' WHERE Id = 1;"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoEntregas");
        }
    }
}
