using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IndexChatbotsOnIsPublicAndVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chatbot_Version_Major",
                table: "Chatbot");

            migrationBuilder.RenameColumn(
                name: "Version_Major",
                table: "Chatbot",
                newName: "VersionMajor");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_IsPublic_VersionMajor",
                table: "Chatbot",
                columns: new[] { "IsPublic", "VersionMajor" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chatbot_IsPublic_VersionMajor",
                table: "Chatbot");

            migrationBuilder.RenameColumn(
                name: "VersionMajor",
                table: "Chatbot",
                newName: "Version_Major");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_Version_Major",
                table: "Chatbot",
                column: "Version_Major",
                unique: true);
        }
    }
}
