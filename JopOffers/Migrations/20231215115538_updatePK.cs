using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JopOffers.Migrations
{
    /// <inheritdoc />
    public partial class updatePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplyForJobs",
                newName: "ApplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplyId",
                table: "ApplyForJobs",
                newName: "Id");
        }
    }
}
