using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedReasonForEachEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Employes");
        }
    }
}
