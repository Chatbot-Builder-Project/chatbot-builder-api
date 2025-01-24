using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDynamicDataFieldToVisualMeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visual_X",
                table: "Port<OutputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_Y",
                table: "Port<OutputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_X",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_Y",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_X",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Visual_Y",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Visual_X",
                table: "FlowLink");

            migrationBuilder.DropColumn(
                name: "Visual_Y",
                table: "FlowLink");

            migrationBuilder.DropColumn(
                name: "Visual_X",
                table: "DataLink");

            migrationBuilder.DropColumn(
                name: "Visual_Y",
                table: "DataLink");

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Port<OutputPortId>",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Port<InputPortId>",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "Node",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "FlowLink",
                type: "NVARCHAR(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visual_Data",
                table: "DataLink",
                type: "NVARCHAR(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Port<OutputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "FlowLink");

            migrationBuilder.DropColumn(
                name: "Visual_Data",
                table: "DataLink");

            migrationBuilder.AddColumn<float>(
                name: "Visual_X",
                table: "Port<OutputPortId>",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_Y",
                table: "Port<OutputPortId>",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_X",
                table: "Port<InputPortId>",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_Y",
                table: "Port<InputPortId>",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_X",
                table: "Node",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_Y",
                table: "Node",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_X",
                table: "FlowLink",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_Y",
                table: "FlowLink",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_X",
                table: "DataLink",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Visual_Y",
                table: "DataLink",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
