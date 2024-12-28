using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataLink");

            migrationBuilder.DropTable(
                name: "Enum_Options");

            migrationBuilder.DropTable(
                name: "FlowLink");

            migrationBuilder.DropTable(
                name: "ImageOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "InteractionInput");

            migrationBuilder.DropTable(
                name: "InteractionOutput");

            migrationBuilder.DropTable(
                name: "OptionOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "StaticNode<ImageData>");

            migrationBuilder.DropTable(
                name: "StaticNode<OptionData>");

            migrationBuilder.DropTable(
                name: "StaticNode<TextData>");

            migrationBuilder.DropTable(
                name: "SwitchNode");

            migrationBuilder.DropTable(
                name: "TextOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "InputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "InputMessage");

            migrationBuilder.DropTable(
                name: "InteractionNode");

            migrationBuilder.DropTable(
                name: "OutputMessage");

            migrationBuilder.DropTable(
                name: "OutputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "InputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "Enum");

            migrationBuilder.DropTable(
                name: "InputPort<TextData>");

            migrationBuilder.DropTable(
                name: "OutputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "PromptNode");

            migrationBuilder.DropTable(
                name: "OutputPort<TextData>");

            migrationBuilder.DropTable(
                name: "Graph");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Chatbot");

            migrationBuilder.DropTable(
                name: "Workflow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chatbot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version_Major = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatbot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chatbot_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatbotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversation_Chatbot_ChatbotId",
                        column: x => x.ChatbotId,
                        principalTable: "Chatbot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Graph",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatbotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graph", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graph_Chatbot_ChatbotId",
                        column: x => x.ChatbotId,
                        principalTable: "Chatbot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Graph_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Graph_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputMessage_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputMessage_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourcePortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataLink_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enum_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowLink_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "OutputPort<TextData>",
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
                    table.PrimaryKey("PK_OutputPort<TextData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPort<TextData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionOutput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpectedOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    OptionExpected = table.Column<bool>(type: "bit", nullable: false),
                    OutputMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TextExpected = table.Column<bool>(type: "bit", nullable: false),
                    TextOutput_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionOutput_OutputMessage_OutputMessageId",
                        column: x => x.OutputMessageId,
                        principalTable: "OutputMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enum_Options",
                columns: table => new
                {
                    EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enum_Options", x => new { x.EnumId, x.Id });
                    table.ForeignKey(
                        name: "FK_Enum_Options_Enum_EnumId",
                        column: x => x.EnumId,
                        principalTable: "Enum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwitchNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bindings = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedOption_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwitchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwitchNode_Enum_EnumId",
                        column: x => x.EnumId,
                        principalTable: "Enum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SwitchNode_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SwitchNode_InputPort<OptionData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<OptionData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_ImageOutputPortInputPort_InputPort<ImageData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<ImageData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageOutputPortInputPort_OutputPort<ImageData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<ImageData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<ImageData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticNode<ImageData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticNode<ImageData>_OutputPort<ImageData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<ImageData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_OptionOutputPortInputPort_InputPort<OptionData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<OptionData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OptionOutputPortInputPort_OutputPort<OptionData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<OptionData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<OptionData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticNode<OptionData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticNode<OptionData>_OutputPort<OptionData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromptNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InjectedTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Template_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromptNode_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptNode_OutputPort<TextData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaticNode<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticNode<TextData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticNode<TextData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticNode<TextData>_OutputPort<TextData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputPort<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromptNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputPort<TextData>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputPort<TextData>_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputPort<TextData>_PromptNode_PromptNodeId",
                        column: x => x.PromptNodeId,
                        principalTable: "PromptNode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InteractionNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptionOutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputEnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TextInputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TextOutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionNode_Enum_OutputEnumId",
                        column: x => x.OutputEnumId,
                        principalTable: "Enum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InteractionNode_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionNode_InputPort<TextData>_TextInputPortId",
                        column: x => x.TextInputPortId,
                        principalTable: "InputPort<TextData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InteractionNode_OutputPort<OptionData>_OptionOutputPortId",
                        column: x => x.OptionOutputPortId,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InteractionNode_OutputPort<TextData>_TextOutputPortId",
                        column: x => x.TextOutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextOutputPortInputPort",
                columns: table => new
                {
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextOutputPortInputPort", x => new { x.OutputPortId, x.InputPortId });
                    table.ForeignKey(
                        name: "FK_TextOutputPortInputPort_InputPort<TextData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<TextData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TextOutputPortInputPort_OutputPort<TextData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InteractionNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Option_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionInput_InputMessage_InputMessageId",
                        column: x => x.InputMessageId,
                        principalTable: "InputMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionInput_InteractionNode_InteractionNodeId",
                        column: x => x.InteractionNodeId,
                        principalTable: "InteractionNode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_Version_Major",
                table: "Chatbot",
                column: "Version_Major",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chatbot_WorkflowId",
                table: "Chatbot",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_ChatbotId",
                table: "Conversation",
                column: "ChatbotId");

            migrationBuilder.CreateIndex(
                name: "IX_DataLink_GraphId",
                table: "DataLink",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Enum_GraphId",
                table: "Enum",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowLink_GraphId",
                table: "FlowLink",
                column: "GraphId");

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
                name: "IX_Graph_CurrentNodeId",
                table: "Graph",
                column: "CurrentNodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Graph_StartNodeId",
                table: "Graph",
                column: "StartNodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Graph_WorkflowId",
                table: "Graph",
                column: "WorkflowId",
                unique: true,
                filter: "[WorkflowId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImageOutputPortInputPort_InputPortId",
                table: "ImageOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_InputMessage_ConversationId",
                table: "InputMessage",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<ImageData>_GraphId",
                table: "InputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_GraphId",
                table: "InputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_GraphId",
                table: "InputPort<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_PromptNodeId",
                table: "InputPort<TextData>",
                column: "PromptNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionInput_InputMessageId",
                table: "InteractionInput",
                column: "InputMessageId",
                unique: true,
                filter: "[InputMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionInput_InteractionNodeId",
                table: "InteractionInput",
                column: "InteractionNodeId",
                unique: true,
                filter: "[InteractionNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_GraphId",
                table: "InteractionNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_OptionOutputPortId",
                table: "InteractionNode",
                column: "OptionOutputPortId",
                unique: true,
                filter: "[OptionOutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_OutputEnumId",
                table: "InteractionNode",
                column: "OutputEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_TextInputPortId",
                table: "InteractionNode",
                column: "TextInputPortId",
                unique: true,
                filter: "[TextInputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_TextOutputPortId",
                table: "InteractionNode",
                column: "TextOutputPortId",
                unique: true,
                filter: "[TextOutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionOutput_OutputMessageId",
                table: "InteractionOutput",
                column: "OutputMessageId",
                unique: true,
                filter: "[OutputMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OptionOutputPortInputPort_InputPortId",
                table: "OptionOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputMessage_ConversationId",
                table: "OutputMessage",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_GraphId",
                table: "OutputPort<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_GraphId",
                table: "OutputPort<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_GraphId",
                table: "OutputPort<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptNode_GraphId",
                table: "PromptNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptNode_OutputPortId",
                table: "PromptNode",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<ImageData>_GraphId",
                table: "StaticNode<ImageData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<ImageData>_OutputPortId",
                table: "StaticNode<ImageData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<OptionData>_GraphId",
                table: "StaticNode<OptionData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<OptionData>_OutputPortId",
                table: "StaticNode<OptionData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<TextData>_GraphId",
                table: "StaticNode<TextData>",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<TextData>_OutputPortId",
                table: "StaticNode<TextData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_EnumId",
                table: "SwitchNode",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_GraphId",
                table: "SwitchNode",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_InputPortId",
                table: "SwitchNode",
                column: "InputPortId",
                unique: true,
                filter: "[InputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TextOutputPortInputPort_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_OwnerId",
                table: "Workflow",
                column: "OwnerId");
        }
    }
}
