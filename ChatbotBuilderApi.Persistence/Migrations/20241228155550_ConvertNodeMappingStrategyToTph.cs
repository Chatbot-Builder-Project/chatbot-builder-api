using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConvertNodeMappingStrategyToTph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version_Major = table.Column<int>(type: "int", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatbotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "InputMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "InteractionOutput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextOutput_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextExpected = table.Column<bool>(type: "bit", nullable: false),
                    OptionExpected = table.Column<bool>(type: "bit", nullable: false),
                    ExpectedOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    OutputMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "DataLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourcePortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enum", x => x.Id);
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
                name: "FlowLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Graph",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatbotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "InputPort<ImageData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "InputPort<TextData>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromptNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    NodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Identifier = table.Column<int>(type: "int", nullable: false),
                    Info_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visual_X = table.Column<float>(type: "real", nullable: false),
                    Visual_Y = table.Column<float>(type: "real", nullable: false),
                    GraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodeType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    TextInputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TextOutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputEnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptionOutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutputOptionMetas = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Template_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InjectedTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaticNode_OutputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaticNode_OutputPortId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaticNode_OutputPortId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InputPortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Bindings = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    SelectedOption_Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Node_Enum_EnumId",
                        column: x => x.EnumId,
                        principalTable: "Enum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_Enum_OutputEnumId",
                        column: x => x.OutputEnumId,
                        principalTable: "Enum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_Graph_GraphId",
                        column: x => x.GraphId,
                        principalTable: "Graph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Node_InputPort<OptionData>_InputPortId",
                        column: x => x.InputPortId,
                        principalTable: "InputPort<OptionData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_InputPort<TextData>_TextInputPortId",
                        column: x => x.TextInputPortId,
                        principalTable: "InputPort<TextData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<ImageData>_StaticNode_OutputPortId",
                        column: x => x.StaticNode_OutputPortId,
                        principalTable: "OutputPort<ImageData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<OptionData>_OptionOutputPortId",
                        column: x => x.OptionOutputPortId,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<OptionData>_StaticNode_OutputPortId1",
                        column: x => x.StaticNode_OutputPortId1,
                        principalTable: "OutputPort<OptionData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<TextData>_OutputPortId",
                        column: x => x.OutputPortId,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<TextData>_StaticNode_OutputPortId2",
                        column: x => x.StaticNode_OutputPortId2,
                        principalTable: "OutputPort<TextData>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Node_OutputPort<TextData>_TextOutputPortId",
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
                    Text_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InteractionNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_InteractionInput_Node_InteractionNodeId",
                        column: x => x.InteractionNodeId,
                        principalTable: "Node",
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
                name: "IX_InteractionOutput_OutputMessageId",
                table: "InteractionOutput",
                column: "OutputMessageId",
                unique: true,
                filter: "[OutputMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_EnumId",
                table: "Node",
                column: "EnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_GraphId",
                table: "Node",
                column: "GraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_InputPortId",
                table: "Node",
                column: "InputPortId",
                unique: true,
                filter: "[InputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_OptionOutputPortId",
                table: "Node",
                column: "OptionOutputPortId",
                unique: true,
                filter: "[OptionOutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_OutputEnumId",
                table: "Node",
                column: "OutputEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Node_OutputPortId",
                table: "Node",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Node_TextInputPortId",
                table: "Node",
                column: "TextInputPortId",
                unique: true,
                filter: "[TextInputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Node_TextOutputPortId",
                table: "Node",
                column: "TextOutputPortId",
                unique: true,
                filter: "[TextOutputPortId] IS NOT NULL");

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
                name: "IX_TextOutputPortInputPort_InputPortId",
                table: "TextOutputPortInputPort",
                column: "InputPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_OwnerId",
                table: "Workflow",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataLink_Graph_GraphId",
                table: "DataLink",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enum_Graph_GraphId",
                table: "Enum",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowLink_Graph_GraphId",
                table: "FlowLink",
                column: "GraphId",
                principalTable: "Graph",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_Node_PromptNodeId",
                table: "InputPort<TextData>",
                column: "PromptNodeId",
                principalTable: "Node",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatbot_Workflow_WorkflowId",
                table: "Chatbot");

            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Workflow_WorkflowId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_Chatbot_ChatbotId",
                table: "Conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_Graph_Chatbot_ChatbotId",
                table: "Graph");

            migrationBuilder.DropForeignKey(
                name: "FK_Enum_Graph_GraphId",
                table: "Enum");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_Graph_GraphId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_Graph_GraphId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Graph_GraphId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<ImageData>_Graph_GraphId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_Graph_GraphId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_Graph_GraphId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Enum_EnumId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Enum_OutputEnumId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_Node_PromptNodeId",
                table: "InputPort<TextData>");

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
                name: "TextOutputPortInputPort");

            migrationBuilder.DropTable(
                name: "InputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "InputMessage");

            migrationBuilder.DropTable(
                name: "OutputMessage");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "Chatbot");

            migrationBuilder.DropTable(
                name: "Graph");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Enum");

            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropTable(
                name: "InputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "InputPort<TextData>");

            migrationBuilder.DropTable(
                name: "OutputPort<ImageData>");

            migrationBuilder.DropTable(
                name: "OutputPort<OptionData>");

            migrationBuilder.DropTable(
                name: "OutputPort<TextData>");
        }
    }
}
