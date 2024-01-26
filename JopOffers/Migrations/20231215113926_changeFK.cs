using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JopOffers.Migrations
{
    /// <inheritdoc />
    public partial class changeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ApplyForJobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ApplyForJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
