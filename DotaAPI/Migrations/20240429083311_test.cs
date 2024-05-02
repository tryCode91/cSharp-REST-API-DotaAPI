using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotaAPI.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbilityDetail_Abilities_AbilityId",
                table: "AbilityDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbilityDetail",
                table: "AbilityDetail");

            migrationBuilder.RenameTable(
                name: "AbilityDetail",
                newName: "AbilityDetails");

            migrationBuilder.RenameIndex(
                name: "IX_AbilityDetail_AbilityId",
                table: "AbilityDetails",
                newName: "IX_AbilityDetails_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbilityDetails",
                table: "AbilityDetails",
                column: "AbilityDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbilityDetails_Abilities_AbilityId",
                table: "AbilityDetails",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbilityDetails_Abilities_AbilityId",
                table: "AbilityDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbilityDetails",
                table: "AbilityDetails");

            migrationBuilder.RenameTable(
                name: "AbilityDetails",
                newName: "AbilityDetail");

            migrationBuilder.RenameIndex(
                name: "IX_AbilityDetails_AbilityId",
                table: "AbilityDetail",
                newName: "IX_AbilityDetail_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbilityDetail",
                table: "AbilityDetail",
                column: "AbilityDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbilityDetail_Abilities_AbilityId",
                table: "AbilityDetail",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "AbilityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
