using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update_09_012023_11_22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityStatus",
                table: "SequenceObjects");

            migrationBuilder.CreateTable(
                name: "EventSequenceObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ActivityStatus = table.Column<int>(type: "int", nullable: false),
                    IsLoginEventObject = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSequenceObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSequenceObjects_EventObjects_EventObjectId",
                        column: x => x.EventObjectId,
                        principalTable: "EventObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSequenceObjects_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSequenceObjects_SequenceObjects_SequenceObjectId",
                        column: x => x.SequenceObjectId,
                        principalTable: "SequenceObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventSequenceObjects_Sequences_SequenceId",
                        column: x => x.SequenceId,
                        principalTable: "Sequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSequenceObjects_EventId",
                table: "EventSequenceObjects",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSequenceObjects_EventObjectId",
                table: "EventSequenceObjects",
                column: "EventObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSequenceObjects_SequenceId",
                table: "EventSequenceObjects",
                column: "SequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSequenceObjects_SequenceObjectId",
                table: "EventSequenceObjects",
                column: "SequenceObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSequenceObjects");

            migrationBuilder.AddColumn<int>(
                name: "ActivityStatus",
                table: "SequenceObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
