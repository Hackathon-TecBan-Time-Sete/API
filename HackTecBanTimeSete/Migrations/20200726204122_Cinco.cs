using Microsoft.EntityFrameworkCore.Migrations;

namespace HackTecBanTimeSete.Migrations
{
    public partial class Cinco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    CompleteName = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DateBirth = table.Column<string>(nullable: true),
                    Mother = table.Column<string>(nullable: true),
                    Father = table.Column<string>(nullable: true),
                    Income = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Segment = table.Column<string>(nullable: true),
                    LastHarvest = table.Column<string>(nullable: true),
                    NumberEmployees = table.Column<string>(nullable: true),
                    NumberMachines = table.Column<string>(nullable: true),
                    Prevent = table.Column<string>(nullable: true),
                    SizeField = table.Column<string>(nullable: true),
                    ExperienceTime = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.AvaliacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");
        }

    }
}
