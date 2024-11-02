using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class TimeslotOnlyReferencesService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Providers_ProviderID",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Timeslots_ProviderID",
                table: "Timeslots");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Timeslots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Timeslots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_ProviderID",
                table: "Timeslots",
                column: "ProviderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Providers_ProviderID",
                table: "Timeslots",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
