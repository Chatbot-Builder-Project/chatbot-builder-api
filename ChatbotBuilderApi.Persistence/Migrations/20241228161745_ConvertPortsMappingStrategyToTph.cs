using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConvertPortsMappingStrategyToTph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_OutputPort<ImageData>_OutputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_Graph_GraphId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_Node_PromptNodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_InputPort<OptionData>_InputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_InputPort<TextData>_TextInputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<ImageData>_StaticNode_OutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<OptionData>_OptionOutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<OptionData>_StaticNode_OutputPortId1",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<TextData>_OutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<TextData>_StaticNode_OutputPortId2",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_OutputPort<TextData>_TextOutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_OutputPort<OptionData>_OutputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_Graph_GraphId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_OutputPort<TextData>_OutputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "InputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "InputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "OutputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "OutputPort<OptionData>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputPort<TextData>",
                table: "OutputPort<TextData>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InputPort<TextData>",
                table: "InputPort<TextData>");

            migrationBuilder.RenameTable(
                name: "OutputPort<TextData>",
                newName: "Port<OutputPortId>");

            migrationBuilder.RenameTable(
                name: "InputPort<TextData>",
                newName: "Port<InputPortId>");

            migrationBuilder.RenameIndex(
                name: "IX_OutputPort<TextData>_GraphId",
                table: "Port<OutputPortId>",
                newName: "IX_Port<OutputPortId>_GraphId");

            migrationBuilder.RenameIndex(
                name: "IX_InputPort<TextData>_PromptNodeId",
                table: "Port<InputPortId>",
                newName: "IX_Port<InputPortId>_PromptNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_InputPort<TextData>_GraphId",
                table: "Port<InputPortId>",
                newName: "IX_Port<InputPortId>_GraphId");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Port<OutputPortId>",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Port<InputPortId>",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Data_Url",
                table: "Port<InputPortId>",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Data_Value",
                table: "Port<InputPortId>",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Port<OutputPortId>",
                table: "Port<OutputPortId>",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Port<InputPortId>",
                table: "Port<InputPortId>",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "ImageOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<InputPortId>_InputPortId",
                table: "Node",
                column: "InputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<InputPortId>_TextInputPortId",
                table: "Node",
                column: "TextInputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_OptionOutputPortId",
                table: "Node",
                column: "OptionOutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_OutputPortId",
                table: "Node",
                column: "OutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Port<OutputPortId>_TextOutputPortId",
                table: "Node",
                column: "TextOutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "OptionOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Port<InputPortId>_Graph_GraphId",
                table: "Port<InputPortId>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Port<InputPortId>_Node_PromptNodeId",
                table: "Port<InputPortId>",
                column: "PromptNodeId",
                principalTable: "Node",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Port<OutputPortId>_Graph_GraphId",
                table: "Port<OutputPortId>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId",
                principalTable: "Port<InputPortId>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "TextOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "Port<OutputPortId>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "ImageOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<InputPortId>_InputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<InputPortId>_TextInputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_OptionOutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_OutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId1",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_StaticNode_OutputPortId2",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Port<OutputPortId>_TextOutputPortId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "OptionOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_Port<InputPortId>_Graph_GraphId",
                table: "Port<InputPortId>");

            migrationBuilder.DropForeignKey(
                name: "FK_Port<InputPortId>_Node_PromptNodeId",
                table: "Port<InputPortId>");

            migrationBuilder.DropForeignKey(
                name: "FK_Port<OutputPortId>_Graph_GraphId",
                table: "Port<OutputPortId>");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_Port<InputPortId>_InputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.DropForeignKey(
                name: "FK_TextOutputPortInputPort_Port<OutputPortId>_OutputPortId",
                table: "TextOutputPortInputPort");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Port<OutputPortId>",
                table: "Port<OutputPortId>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Port<InputPortId>",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Port<OutputPortId>");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "Data_Url",
                table: "Port<InputPortId>");

            migrationBuilder.DropColumn(
                name: "Data_Value",
                table: "Port<InputPortId>");

            migrationBuilder.RenameTable(
                name: "Port<OutputPortId>",
                newName: "OutputPort<TextData>");

            migrationBuilder.RenameTable(
                name: "Port<InputPortId>",
                newName: "InputPort<TextData>");

            migrationBuilder.RenameIndex(
                name: "IX_Port<OutputPortId>_GraphId",
                table: "OutputPort<TextData>",
                newName: "IX_OutputPort<TextData>_GraphId");

            migrationBuilder.RenameIndex(
                name: "IX_Port<InputPortId>_PromptNodeId",
                table: "InputPort<TextData>",
                newName: "IX_InputPort<TextData>_PromptNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Port<InputPortId>_GraphId",
                table: "InputPort<TextData>",
                newName: "IX_InputPort<TextData>_GraphId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputPort<TextData>",
                table: "OutputPort<TextData>",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InputPort<TextData>",
                table: "InputPort<TextData>",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InputPort<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<ImageData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputPort<ImageData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputPort<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<OptionData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputPort<OptionData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputPort<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPort<ImageData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<ImageData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputPort<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPort<OptionData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<OptionData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<ImageData>_GraphId",
                table: "InputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_GraphId",
                table: "InputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_GraphId",
                table: "OutputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_GraphId",
                table: "OutputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageOutputPortInputPort_OutputPort<ImageData>_OutputPortId",
                table: "ImageOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "OutputPort<ImageData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_Graph_GraphId",
                table: "InputPort<TextData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_Node_PromptNodeId",
                table: "InputPort<TextData>",
                column: "PromptNodeId",
                principalTable: "Node",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_InputPort<OptionData>_InputPortId",
                table: "Node",
                column: "InputPortId",
                principalTable: "InputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_InputPort<TextData>_TextInputPortId",
                table: "Node",
                column: "TextInputPortId",
                principalTable: "InputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<ImageData>_StaticNode_OutputPortId",
                table: "Node",
                column: "StaticNode_OutputPortId",
                principalTable: "OutputPort<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<OptionData>_OptionOutputPortId",
                table: "Node",
                column: "OptionOutputPortId",
                principalTable: "OutputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<OptionData>_StaticNode_OutputPortId1",
                table: "Node",
                column: "StaticNode_OutputPortId1",
                principalTable: "OutputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<TextData>_OutputPortId",
                table: "Node",
                column: "OutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<TextData>_StaticNode_OutputPortId2",
                table: "Node",
                column: "StaticNode_OutputPortId2",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_OutputPort<TextData>_TextOutputPortId",
                table: "Node",
                column: "TextOutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionOutputPortInputPort_OutputPort<OptionData>_OutputPortId",
                table: "OptionOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "OutputPort<OptionData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_Graph_GraphId",
                table: "OutputPort<TextData>",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId",
                principalTable: "InputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextOutputPortInputPort_OutputPort<TextData>_OutputPortId",
                table: "TextOutputPortInputPort",
                column: "OutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
