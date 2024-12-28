using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameToSourceAndTarget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutputNodeId",
                table: "FlowLink",
                newName: "TargetNodeId");

            migrationBuilder.RenameColumn(
                name: "InputNodeId",
                table: "FlowLink",
                newName: "SourceNodeId");

            migrationBuilder.RenameColumn(
                name: "OutputPortId",
                table: "DataLink",
                newName: "TargetPortId");

            migrationBuilder.RenameColumn(
                name: "InputPortId",
                table: "DataLink",
                newName: "SourcePortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetNodeId",
                table: "FlowLink",
                newName: "OutputNodeId");

            migrationBuilder.RenameColumn(
                name: "SourceNodeId",
                table: "FlowLink",
                newName: "InputNodeId");

            migrationBuilder.RenameColumn(
                name: "TargetPortId",
                table: "DataLink",
                newName: "OutputPortId");

            migrationBuilder.RenameColumn(
                name: "SourcePortId",
                table: "DataLink",
                newName: "InputPortId");
        }
    }
}
