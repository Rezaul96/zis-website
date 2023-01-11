using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update_10_01_2023_12_30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventShares_Sequences_SequenceId",
                table: "EventShares");

            migrationBuilder.DropColumn(
                name: "Control",
                table: "EventObjects");

            migrationBuilder.RenameColumn(
                name: "SequenceId",
                table: "EventShares",
                newName: "EventObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EventShares_SequenceId",
                table: "EventShares",
                newName: "IX_EventShares_EventObjectId");

            migrationBuilder.AlterColumn<bool>(
                name: "Share",
                table: "EventObjects",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentEventObjectId",
                table: "EventObjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventShares_EventObjects_EventObjectId",
                table: "EventShares",
                column: "EventObjectId",
                principalTable: "EventObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventShares_EventObjects_EventObjectId",
                table: "EventShares");

            migrationBuilder.DropColumn(
                name: "ParentEventObjectId",
                table: "EventObjects");

            migrationBuilder.RenameColumn(
                name: "EventObjectId",
                table: "EventShares",
                newName: "SequenceId");

            migrationBuilder.RenameIndex(
                name: "IX_EventShares_EventObjectId",
                table: "EventShares",
                newName: "IX_EventShares_SequenceId");

            migrationBuilder.AlterColumn<string>(
                name: "Share",
                table: "EventObjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Control",
                table: "EventObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventShares_Sequences_SequenceId",
                table: "EventShares",
                column: "SequenceId",
                principalTable: "Sequences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
