using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sverlov.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automodiles_TheTransportTypes_TheTransportTypeId",
                table: "Automodiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Automodiles",
                table: "Automodiles");

            migrationBuilder.RenameTable(
                name: "Automodiles",
                newName: "Automobiles");

            migrationBuilder.RenameIndex(
                name: "IX_Automodiles_TheTransportTypeId",
                table: "Automobiles",
                newName: "IX_Automobiles_TheTransportTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Automobiles",
                table: "Automobiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_TheTransportTypes_TheTransportTypeId",
                table: "Automobiles",
                column: "TheTransportTypeId",
                principalTable: "TheTransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobiles_TheTransportTypes_TheTransportTypeId",
                table: "Automobiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Automobiles",
                table: "Automobiles");

            migrationBuilder.RenameTable(
                name: "Automobiles",
                newName: "Automodiles");

            migrationBuilder.RenameIndex(
                name: "IX_Automobiles_TheTransportTypeId",
                table: "Automodiles",
                newName: "IX_Automodiles_TheTransportTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Automodiles",
                table: "Automodiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Automodiles_TheTransportTypes_TheTransportTypeId",
                table: "Automodiles",
                column: "TheTransportTypeId",
                principalTable: "TheTransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
