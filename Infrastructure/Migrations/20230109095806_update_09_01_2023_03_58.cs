using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update_09_01_2023_03_58 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventShares_Events_EventId",
                table: "EventShares");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventShares",
                newName: "SequenceId");

            migrationBuilder.RenameIndex(
                name: "IX_EventShares_EventId",
                table: "EventShares",
                newName: "IX_EventShares_SequenceId");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Events_MemberId",
                table: "Events",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventShares_Sequences_SequenceId",
                table: "EventShares",
                column: "SequenceId",
                principalTable: "Sequences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Members_MemberId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventShares_Sequences_SequenceId",
                table: "EventShares");

            migrationBuilder.DropIndex(
                name: "IX_Events_MemberId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "SequenceId",
                table: "EventShares",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventShares_SequenceId",
                table: "EventShares",
                newName: "IX_EventShares_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventShares_Events_EventId",
                table: "EventShares",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
