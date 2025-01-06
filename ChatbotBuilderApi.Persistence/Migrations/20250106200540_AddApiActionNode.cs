using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddApiActionNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionResponse",
                table: "Node",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BodyInputPortId",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Headers",
                table: "Node",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HttpMethod",
                table: "Node",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponseOutputPortId",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UrlInputPortId",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Node_BodyInputPortId",
                table: "Node",
                column: "BodyInputPortId",
                unique: true,
                filter: "[BodyInputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_ResponseOutputPortId",
                table: "Node",
                column: "ResponseOutputPortId",
                unique: true,
                filter: "[ResponseOutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_UrlInputPortId",
                table: "Node",
                column: "UrlInputPortId",
                unique: true,
                filter: "[UrlInputPortId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<InputPortId>_BodyInputPortId",
                table: "Node",
                column: "BodyInputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<InputPortId>_UrlInputPortId",
                table: "Node",
                column: "UrlInputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_ResponseOutputPortId",
                table: "Node",
                column: "ResponseOutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<InputPortId>_BodyInputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<InputPortId>_UrlInputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_ResponseOutputPortId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_BodyInputPortId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_ResponseOutputPortId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_UrlInputPortId",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "ActionResponse",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "BodyInputPortId",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Headers",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "HttpMethod",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "ResponseOutputPortId",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "UrlInputPortId",
                table: "Node");
        }
    }
}
