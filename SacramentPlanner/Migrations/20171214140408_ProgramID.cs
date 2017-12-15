using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner.Migrations
{
    public partial class ProgramID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingProgram",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Conduct = table.Column<string>(maxLength: 50, nullable: false),
                    Preside = table.Column<string>(maxLength: 50, nullable: false),
                    Sacrament = table.Column<bool>(nullable: false),
                    programDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingProgram", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingProgramid = table.Column<int>(nullable: true),
                    hymnNumber = table.Column<int>(nullable: false),
                    location = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    programID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hymn_MeetingProgram_MeetingProgramid",
                        column: x => x.MeetingProgramid,
                        principalTable: "MeetingProgram",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prayer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingProgramid = table.Column<int>(nullable: true),
                    location = table.Column<int>(nullable: false),
                    programID = table.Column<int>(nullable: false),
                    speaker = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prayer_MeetingProgram_MeetingProgramid",
                        column: x => x.MeetingProgramid,
                        principalTable: "MeetingProgram",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingProgramid = table.Column<int>(nullable: true),
                    Reading = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: false),
                    programID = table.Column<int>(nullable: false),
                    speaker = table.Column<string>(maxLength: 50, nullable: false),
                    topic = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.id);
                    table.ForeignKey(
                        name: "FK_Talk_MeetingProgram_MeetingProgramid",
                        column: x => x.MeetingProgramid,
                        principalTable: "MeetingProgram",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hymn_MeetingProgramid",
                table: "Hymn",
                column: "MeetingProgramid");

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_MeetingProgramid",
                table: "Prayer",
                column: "MeetingProgramid");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_MeetingProgramid",
                table: "Talk",
                column: "MeetingProgramid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Prayer");

            migrationBuilder.DropTable(
                name: "Talk");

            migrationBuilder.DropTable(
                name: "MeetingProgram");
        }
    }
}
