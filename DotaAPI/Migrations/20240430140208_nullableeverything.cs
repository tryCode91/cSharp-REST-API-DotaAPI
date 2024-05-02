using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotaAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullableeverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Heroes_HeroId",
                table: "Characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Heroes_HeroId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_HeroId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_HeroId",
                table: "Characteristics");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Stats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Characteristics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_HeroId",
                table: "Stats",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_HeroId",
                table: "Characteristics",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Heroes_HeroId",
                table: "Characteristics",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Heroes_HeroId",
                table: "Stats",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Heroes_HeroId",
                table: "Characteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Heroes_HeroId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_HeroId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_HeroId",
                table: "Characteristics");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Characteristics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_HeroId",
                table: "Stats",
                column: "HeroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_HeroId",
                table: "Characteristics",
                column: "HeroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Heroes_HeroId",
                table: "Characteristics",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Heroes_HeroId",
                table: "Stats",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
