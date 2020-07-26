using Microsoft.EntityFrameworkCore.Migrations;

namespace HackTecBanTimeSete.Migrations
{
    public partial class Dois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "GroupsSchedules",
                columns: table => new
                {
                    GroupsScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsSchedules", x => x.GroupsScheduleId);
                    table.ForeignKey(
                        name: "FK_GroupsSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionSchedule",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SessionScheduleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TimeStart = table.Column<string>(nullable: true),
                    TimeEnd = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    GroupsScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionSchedule_GroupsSchedules_GroupsScheduleId",
                        column: x => x.GroupsScheduleId,
                        principalTable: "GroupsSchedules",
                        principalColumn: "GroupsScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    track = table.Column<string>(nullable: true),
                    SessionScheduleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_SessionSchedule_SessionScheduleId",
                        column: x => x.SessionScheduleId,
                        principalTable: "SessionSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsSchedules_ScheduleId",
                table: "GroupsSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSchedule_GroupsScheduleId",
                table: "SessionSchedule",
                column: "GroupsScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_SessionScheduleId",
                table: "Tracks",
                column: "SessionScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "SessionSchedule");

            migrationBuilder.DropTable(
                name: "GroupsSchedules");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");
        }
    }
}
