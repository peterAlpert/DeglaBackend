using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_injuries_Members_MemberId",
                table: "injuries");

            migrationBuilder.DropForeignKey(
                name: "FK_violations_Members_MemberId",
                table: "violations");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "violations");

            migrationBuilder.DropColumn(
                name: "InjuryLocation",
                table: "injuries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "violations",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "violations",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "violations",
                newName: "memberId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "violations",
                newName: "date");

            migrationBuilder.RenameIndex(
                name: "IX_violations_MemberId",
                table: "violations",
                newName: "IX_violations_memberId");

            migrationBuilder.RenameColumn(
                name: "StadeNo",
                table: "injuries",
                newName: "stadeNo");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "injuries",
                newName: "memberId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "injuries",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "ActionTaken",
                table: "injuries",
                newName: "actionTaken");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "injuries",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "InjuryType",
                table: "injuries",
                newName: "location");

            migrationBuilder.RenameIndex(
                name: "IX_injuries_MemberId",
                table: "injuries",
                newName: "IX_injuries_memberId");

            migrationBuilder.AddForeignKey(
                name: "FK_injuries_Members_memberId",
                table: "injuries",
                column: "memberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_violations_Members_memberId",
                table: "violations",
                column: "memberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_injuries_Members_memberId",
                table: "injuries");

            migrationBuilder.DropForeignKey(
                name: "FK_violations_Members_memberId",
                table: "violations");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "violations",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "violations",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "memberId",
                table: "violations",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "violations",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_violations_memberId",
                table: "violations",
                newName: "IX_violations_MemberId");

            migrationBuilder.RenameColumn(
                name: "stadeNo",
                table: "injuries",
                newName: "StadeNo");

            migrationBuilder.RenameColumn(
                name: "memberId",
                table: "injuries",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "injuries",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "actionTaken",
                table: "injuries",
                newName: "ActionTaken");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "injuries",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "injuries",
                newName: "InjuryType");

            migrationBuilder.RenameIndex(
                name: "IX_injuries_memberId",
                table: "injuries",
                newName: "IX_injuries_MemberId");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "violations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InjuryLocation",
                table: "injuries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_injuries_Members_MemberId",
                table: "injuries",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_violations_Members_MemberId",
                table: "violations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
