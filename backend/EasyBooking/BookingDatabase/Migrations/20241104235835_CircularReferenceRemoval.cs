using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class CircularReferenceRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Clients_ClientID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Providers_ProviderID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_ServiceID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Timeslots_TimeslotID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Clients_ClientID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Providers_ProviderID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Providers_ProviderID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Services_ServiceID",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Timeslots_ServiceID",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProviderID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClientID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ServiceID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TimeslotID",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ServiceModelID",
                table: "Timeslots",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelID",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientModelID",
                table: "Reviews",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderModelID",
                table: "Reviews",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientModelID",
                table: "Bookings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeslotModelID",
                table: "Bookings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_ServiceModelID",
                table: "Timeslots",
                column: "ServiceModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderModelID",
                table: "Services",
                column: "ProviderModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientModelID",
                table: "Reviews",
                column: "ClientModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProviderModelID",
                table: "Reviews",
                column: "ProviderModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientModelID",
                table: "Bookings",
                column: "ClientModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeslotModelID",
                table: "Bookings",
                column: "TimeslotModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Clients_ClientModelID",
                table: "Bookings",
                column: "ClientModelID",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Timeslots_TimeslotModelID",
                table: "Bookings",
                column: "TimeslotModelID",
                principalTable: "Timeslots",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Clients_ClientModelID",
                table: "Reviews",
                column: "ClientModelID",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Providers_ProviderModelID",
                table: "Reviews",
                column: "ProviderModelID",
                principalTable: "Providers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Providers_ProviderModelID",
                table: "Services",
                column: "ProviderModelID",
                principalTable: "Providers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Services_ServiceModelID",
                table: "Timeslots",
                column: "ServiceModelID",
                principalTable: "Services",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Clients_ClientModelID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Timeslots_TimeslotModelID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Clients_ClientModelID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Providers_ProviderModelID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Providers_ProviderModelID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Services_ServiceModelID",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Timeslots_ServiceModelID",
                table: "Timeslots");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProviderModelID",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ClientModelID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProviderModelID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClientModelID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TimeslotModelID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ServiceModelID",
                table: "Timeslots");

            migrationBuilder.DropColumn(
                name: "ProviderModelID",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ClientModelID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProviderModelID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ClientModelID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TimeslotModelID",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_ServiceID",
                table: "Timeslots",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProviderID",
                table: "Reviews",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientID",
                table: "Bookings",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceID",
                table: "Bookings",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeslotID",
                table: "Bookings",
                column: "TimeslotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Clients_ClientID",
                table: "Bookings",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Providers_ProviderID",
                table: "Bookings",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_ServiceID",
                table: "Bookings",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Timeslots_TimeslotID",
                table: "Bookings",
                column: "TimeslotID",
                principalTable: "Timeslots",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Clients_ClientID",
                table: "Reviews",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Providers_ProviderID",
                table: "Reviews",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Providers_ProviderID",
                table: "Services",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Services_ServiceID",
                table: "Timeslots",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
