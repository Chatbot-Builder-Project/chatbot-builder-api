using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInteractionOutputImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InteractionNodeId",
                table: "Port<InputPortId>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InteractionOutput_ImageOutputs",
                columns: table => new
                {
                    InteractionOutputId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionOutput_ImageOutputs", x => new { x.InteractionOutputId, x.Id });
                    table.ForeignKey(
                        name: "FK_InteractionOutput_ImageOutputs_InteractionOutput_InteractionOutputId",
                        column: x => x.InteractionOutputId,
                        principalTable: "InteractionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Port<InputPortId>_InteractionNodeId",
                table: "Port<InputPortId>",
                column: "InteractionNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Port<InputPortId>_Node_InteractionNodeId",
                table: "Port<InputPortId>",
                column: "InteractionNodeId",
                principalTable: "Node",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Port<InputPortId>_Node_InteractionNodeId",
                table: "Port<InputPortId>");

            migrationBuilder.DropTable(
                name: "InteractionOutput_ImageOutputs");

            migrationBuilder.DropIndex(
                name: "IX_Port<InputPortId>_InteractionNodeId",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "InteractionNodeId",
                table: "Port<InputPortId>");
        }
    }
}
