using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerFieldToConversations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Conversation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_OwnerId",
                table: "Conversation",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_AspNetUsers_OwnerId",
                table: "Conversation",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_AspNetUsers_OwnerId",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_OwnerId",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Conversation");
        }
    }
}
