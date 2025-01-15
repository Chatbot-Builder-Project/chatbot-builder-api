using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixChatbotsVersionIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chatbot_IsPublic_VersionMajor",
                table: "Chatbot");

            migrationBuilder.DropIndex(
                name: "IX_Chatbot_WorkflowId",
                table: "Chatbot");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_WorkflowId_IsPublic_VersionMajor",
                table: "Chatbot",
                columns: new[] { "WorkflowId", "IsPublic", "VersionMajor" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chatbot_WorkflowId_IsPublic_VersionMajor",
                table: "Chatbot");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_IsPublic_VersionMajor",
                table: "Chatbot",
                columns: new[] { "IsPublic", "VersionMajor" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_WorkflowId",
                table: "Chatbot",
                column: "WorkflowId");
        }
    }
}
