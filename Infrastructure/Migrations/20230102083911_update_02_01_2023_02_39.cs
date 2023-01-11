using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class update_02_01_2023_02_39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Teams",
                schema: "Identity",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                schema: "Identity",
                newName: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "Sequences",
                schema: "Identity",
                newName: "Sequences");

            migrationBuilder.RenameTable(
                name: "SequenceObjects",
                schema: "Identity",
                newName: "SequenceObjects");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Regions",
                schema: "Identity",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                schema: "Identity",
                newName: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "ParticipantImages",
                schema: "Identity",
                newName: "ParticipantImages");

            migrationBuilder.RenameTable(
                name: "ObjectTypes",
                schema: "Identity",
                newName: "ObjectTypes");

            migrationBuilder.RenameTable(
                name: "Industries",
                schema: "Identity",
                newName: "Industries");

            migrationBuilder.RenameTable(
                name: "EventScorerecords",
                schema: "Identity",
                newName: "EventScorerecords");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "Identity",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "EventObjects",
                schema: "Identity",
                newName: "EventObjects");

            migrationBuilder.RenameTable(
                name: "EventObjectDetails",
                schema: "Identity",
                newName: "EventObjectDetails");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "Identity",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "BroadcastImages",
                schema: "Identity",
                newName: "BroadcastImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Teams",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMembers",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Sequences",
                newName: "Sequences",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "SequenceObjects",
                newName: "SequenceObjects",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Regions",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshToken",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "ParticipantImages",
                newName: "ParticipantImages",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "ObjectTypes",
                newName: "ObjectTypes",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Industries",
                newName: "Industries",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "EventScorerecords",
                newName: "EventScorerecords",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Events",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "EventObjects",
                newName: "EventObjects",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "EventObjectDetails",
                newName: "EventObjectDetails",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companies",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "BroadcastImages",
                newName: "BroadcastImages",
                newSchema: "Identity");
        }
    }
}
