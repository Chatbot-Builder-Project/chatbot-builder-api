using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixNodePortsAndEnumsReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId1",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId2",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_EnumId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_OutputEnumId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_StaticNode_OutputPortId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_StaticNode_OutputPortId1",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_StaticNode_OutputPortId2",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "StaticNode_OutputPortId",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "StaticNode_OutputPortId1",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "StaticNode_OutputPortId2",
                table: "Node");

            migrationBuilder.CreateIndex(
                name: "IX_Node_EnumId",
                table: "Node",
                column: "EnumId",
                unique: true,
                filter: "[EnumId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_OutputEnumId",
                table: "Node",
                column: "OutputEnumId",
                unique: true,
                filter: "[OutputEnumId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Node_EnumId",
                table: "Node");

            migrationBuilder.DropIndex(
                name: "IX_Node_OutputEnumId",
                table: "Node");

            migrationBuilder.AddColumn<Guid>(
                name: "StaticNode_OutputPortId",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StaticNode_OutputPortId1",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StaticNode_OutputPortId2",
                table: "Node",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Node_EnumId",
                table: "Node",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_OutputEnumId",
                table: "Node",
                column: "OutputEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_StaticNode_OutputPortId",
                table: "Node",
                column: "StaticNode_OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_StaticNode_OutputPortId1",
                table: "Node",
                column: "StaticNode_OutputPortId1",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_StaticNode_OutputPortId2",
                table: "Node",
                column: "StaticNode_OutputPortId2",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId",
                table: "Node",
                column: "StaticNode_OutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId1",
                table: "Node",
                column: "StaticNode_OutputPortId1",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId2",
                table: "Node",
                column: "StaticNode_OutputPortId2",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");
        }
    }
}
