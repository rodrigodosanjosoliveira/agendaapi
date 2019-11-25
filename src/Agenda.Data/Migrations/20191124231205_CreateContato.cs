using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Data.Migrations
{
  public partial class CreateContato : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Contatos",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            DateCreated = table.Column<DateTime>(nullable: false),
            DateUpdated = table.Column<DateTime>(nullable: true),
            Nome = table.Column<string>(nullable: true),
            Canal = table.Column<string>(nullable: true),
            Valor = table.Column<string>(nullable: true),
            Observacoes = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Contatos", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Contatos");
    }
  }
}
