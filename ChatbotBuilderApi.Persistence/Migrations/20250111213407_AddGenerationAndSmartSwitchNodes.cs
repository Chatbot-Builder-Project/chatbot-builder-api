using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGenerationAndSmartSwitchNodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneratedOutput_Text",
                table: "Node",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options_ResponseSchema",
                table: "Node",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Options_UseMemory",
                table: "Node",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedOutput_Text",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Options_ResponseSchema",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Options_UseMemory",
                table: "Node");
        }
    }
}
