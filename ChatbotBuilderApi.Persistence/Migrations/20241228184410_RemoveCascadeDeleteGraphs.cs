using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCascadeDeleteGraphs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Chatbot_ChatbotId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Conversation_ConversationId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Workflow_WorkflowId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_ChatbotId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_ConversationId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_WorkflowId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "ChatbotId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Graph");

            migrationBuilder.DropColumn(
                name: "WorkflowId",
                table: "Graph");

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "Workflow",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "Conversation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GraphId",
                table: "Chatbot",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_GraphId",
                table: "Workflow",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_GraphId",
                table: "Conversation",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_GraphId",
                table: "Chatbot",
                column: "GraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chatbot_Graph_GraphId",
                table: "Chatbot",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_Graph_GraphId",
                table: "Conversation",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workflow_Graph_GraphId",
                table: "Workflow",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatbot_Graph_GraphId",
                table: "Chatbot");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_Graph_GraphId",
                table: "Conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_Workflow_Graph_GraphId",
                table: "Workflow");

            migrationBuilder.DropIndex(
                name: "IX_Workflow_GraphId",
                table: "Workflow");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_GraphId",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Chatbot_GraphId",
                table: "Chatbot");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "GraphId",
                table: "Chatbot");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatbotId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkflowId",
                table: "Graph",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Graph_ChatbotId",
                table: "Graph",
                column: "ChatbotId",
                unique: true,
                filter: "[ChatbotId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Graph_ConversationId",
                table: "Graph",
                column: "ConversationId",
                unique: true,
                filter: "[ConversationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Graph_WorkflowId",
                table: "Graph",
                column: "WorkflowId",
                unique: true,
                filter: "[WorkflowId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Chatbot_ChatbotId",
                table: "Graph",
                column: "ChatbotId",
                principalTable: "Chatbot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Conversation_ConversationId",
                table: "Graph",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Workflow_WorkflowId",
                table: "Graph",
                column: "WorkflowId",
                principalTable: "Workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
