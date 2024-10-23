using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddUniques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_ProviderID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderID_Name",
                table: "Services",
                columns: new[] { "ProviderID", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CNPJ",
                table: "Providers",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Email",
                table: "Providers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Name",
                table: "Providers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CPF",
                table: "Clients",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_ProviderID_Name",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Providers_CNPJ",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_Email",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_Name",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CPF",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderID",
                table: "Services",
                column: "ProviderID");
        }
    }
}
