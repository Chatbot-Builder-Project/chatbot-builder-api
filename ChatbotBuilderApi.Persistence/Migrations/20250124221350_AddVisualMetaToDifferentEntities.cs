using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVisualMetaToDifferentEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Workflow",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Conversation",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Chatbot",
                type: "NVARCHAR(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Chatbot");
        }
    }
}
