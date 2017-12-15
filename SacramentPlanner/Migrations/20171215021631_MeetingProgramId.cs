using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner.Migrations
{
    public partial class MeetingProgramId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hymn_MeetingProgram_MeetingProgramid",
                table: "Hymn");

            migrationBuilder.DropForeignKey(
                name: "FK_Prayer_MeetingProgram_MeetingProgramid",
                table: "Prayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_MeetingProgram_MeetingProgramid",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "programID",
                table: "Talk");

            migrationBuilder.DropColumn(
                name: "programID",
                table: "Prayer");

            migrationBuilder.DropColumn(
                name: "programID",
                table: "Hymn");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramid",
                table: "Talk",
                newName: "MeetingProgramID");

            migrationBuilder.RenameIndex(
                name: "IX_Talk_MeetingProgramid",
                table: "Talk",
                newName: "IX_Talk_MeetingProgramID");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramid",
                table: "Prayer",
                newName: "MeetingProgramID");

            migrationBuilder.RenameIndex(
                name: "IX_Prayer_MeetingProgramid",
                table: "Prayer",
                newName: "IX_Prayer_MeetingProgramID");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramid",
                table: "Hymn",
                newName: "MeetingProgramID");

            migrationBuilder.RenameIndex(
                name: "IX_Hymn_MeetingProgramid",
                table: "Hymn",
                newName: "IX_Hymn_MeetingProgramID");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramID",
                table: "Talk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramID",
                table: "Prayer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramID",
                table: "Hymn",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hymn_MeetingProgram_MeetingProgramID",
                table: "Hymn",
                column: "MeetingProgramID",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prayer_MeetingProgram_MeetingProgramID",
                table: "Prayer",
                column: "MeetingProgramID",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_MeetingProgram_MeetingProgramID",
                table: "Talk",
                column: "MeetingProgramID",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hymn_MeetingProgram_MeetingProgramID",
                table: "Hymn");

            migrationBuilder.DropForeignKey(
                name: "FK_Prayer_MeetingProgram_MeetingProgramID",
                table: "Prayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Talk_MeetingProgram_MeetingProgramID",
                table: "Talk");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramID",
                table: "Talk",
                newName: "MeetingProgramid");

            migrationBuilder.RenameIndex(
                name: "IX_Talk_MeetingProgramID",
                table: "Talk",
                newName: "IX_Talk_MeetingProgramid");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramID",
                table: "Prayer",
                newName: "MeetingProgramid");

            migrationBuilder.RenameIndex(
                name: "IX_Prayer_MeetingProgramID",
                table: "Prayer",
                newName: "IX_Prayer_MeetingProgramid");

            migrationBuilder.RenameColumn(
                name: "MeetingProgramID",
                table: "Hymn",
                newName: "MeetingProgramid");

            migrationBuilder.RenameIndex(
                name: "IX_Hymn_MeetingProgramID",
                table: "Hymn",
                newName: "IX_Hymn_MeetingProgramid");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramid",
                table: "Talk",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "programID",
                table: "Talk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramid",
                table: "Prayer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "programID",
                table: "Prayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingProgramid",
                table: "Hymn",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "programID",
                table: "Hymn",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Hymn_MeetingProgram_MeetingProgramid",
                table: "Hymn",
                column: "MeetingProgramid",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prayer_MeetingProgram_MeetingProgramid",
                table: "Prayer",
                column: "MeetingProgramid",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talk_MeetingProgram_MeetingProgramid",
                table: "Talk",
                column: "MeetingProgramid",
                principalTable: "MeetingProgram",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
