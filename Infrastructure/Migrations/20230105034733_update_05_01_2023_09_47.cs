using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update_05_01_2023_09_47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Sequences");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SequenceObjects");

            migrationBuilder.AddColumn<int>(
                name: "ActivityStatus",
                table: "SequenceObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "SequenceObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SequenceId",
                table: "SequenceObjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventObjectId",
                table: "EventObjectDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SequenceObjects_SequenceId",
                table: "SequenceObjects",
                column: "SequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventObjectDetails_EventObjectId",
                table: "EventObjectDetails",
                column: "EventObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventObjectDetails_EventObjects_EventObjectId",
                table: "EventObjectDetails",
                column: "EventObjectId",
                principalTable: "EventObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SequenceObjects_Sequences_SequenceId",
                table: "SequenceObjects",
                column: "SequenceId",
                principalTable: "Sequences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventObjectDetails_EventObjects_EventObjectId",
                table: "EventObjectDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SequenceObjects_Sequences_SequenceId",
                table: "SequenceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SequenceObjects_SequenceId",
                table: "SequenceObjects");

            migrationBuilder.DropIndex(
                name: "IX_EventObjectDetails_EventObjectId",
                table: "EventObjectDetails");

            migrationBuilder.DropColumn(
                name: "ActivityStatus",
                table: "SequenceObjects");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "SequenceObjects");

            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "SequenceObjects");

            migrationBuilder.DropColumn(
                name: "EventObjectId",
                table: "EventObjectDetails");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Sequences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SequenceObjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
