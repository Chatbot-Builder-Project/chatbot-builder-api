using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStartAndCurrentNodeGraphRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Node_CurrentNodeId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Node_StartNodeId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_CurrentNodeId",
                table: "Graph");

            migrationBuilder.DropIndex(
                name: "IX_Graph_StartNodeId",
                table: "Graph");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Graph_CurrentNodeId",
                table: "Graph",
                column: "CurrentNodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Graph_StartNodeId",
                table: "Graph",
                column: "StartNodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Node_CurrentNodeId",
                table: "Graph",
                column: "CurrentNodeId",
                principalTable: "Node",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Graph_Node_StartNodeId",
                table: "Graph",
                column: "StartNodeId",
                principalTable: "Node",
                principalColumn: "Id");
        }
    }
}
