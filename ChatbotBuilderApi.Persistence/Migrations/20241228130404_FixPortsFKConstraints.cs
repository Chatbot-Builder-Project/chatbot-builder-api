using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotBuilderApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixPortsFKConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_InteractionNode_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_PromptNode_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnumId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "InputPortId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OutputPortId",
                table: "StaticNode<TextData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OutputPortId",
                table: "StaticNode<OptionData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OutputPortId",
                table: "StaticNode<ImageData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OutputPortId",
                table: "PromptNode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OptionOutputPortId",
                table: "InteractionNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TextInputPortId",
                table: "InteractionNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TextOutputPortId",
                table: "InteractionNode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PromptNodeId",
                table: "InputPort<TextData>",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwitchNode_InputPortId",
                table: "SwitchNode",
                column: "InputPortId",
                unique: true,
                filter: "[InputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<TextData>_OutputPortId",
                table: "StaticNode<TextData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<OptionData>_OutputPortId",
                table: "StaticNode<OptionData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaticNode<ImageData>_OutputPortId",
                table: "StaticNode<ImageData>",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PromptNode_OutputPortId",
                table: "PromptNode",
                column: "OutputPortId",
                unique: true,
                filter: "[OutputPortId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionNode_OptionOutputPortId",
                table: "InteractionNode",
                column: "OptionOutputPortId",
                unique: true,
                filter: "[OptionOutputPortId] IS NOT NULL");

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
                name: "IX_InputPort<TextData>_PromptNodeId",
                table: "InputPort<TextData>",
                column: "PromptNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_PromptNodeId",
                table: "InputPort<TextData>",
                column: "PromptNodeId",
                principalTable: "PromptNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionNode_InputPort<TextData>_TextInputPortId",
                table: "InteractionNode",
                column: "TextInputPortId",
                principalTable: "InputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionNode_OutputPort<OptionData>_OptionOutputPortId",
                table: "InteractionNode",
                column: "OptionOutputPortId",
                principalTable: "OutputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionNode_OutputPort<TextData>_TextOutputPortId",
                table: "InteractionNode",
                column: "TextOutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromptNode_OutputPort<TextData>_OutputPortId",
                table: "PromptNode",
                column: "OutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<ImageData>_OutputPort<ImageData>_OutputPortId",
                table: "StaticNode<ImageData>",
                column: "OutputPortId",
                principalTable: "OutputPort<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<OptionData>_OutputPort<OptionData>_OutputPortId",
                table: "StaticNode<OptionData>",
                column: "OutputPortId",
                principalTable: "OutputPort<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticNode<TextData>_OutputPort<TextData>_OutputPortId",
                table: "StaticNode<TextData>",
                column: "OutputPortId",
                principalTable: "OutputPort<TextData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SwitchNode_InputPort<OptionData>_InputPortId",
                table: "SwitchNode",
                column: "InputPortId",
                principalTable: "InputPort<OptionData>",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_PromptNodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionNode_InputPort<TextData>_TextInputPortId",
                table: "InteractionNode");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionNode_OutputPort<OptionData>_OptionOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionNode_OutputPort<TextData>_TextOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropForeignKey(
                name: "FK_PromptNode_OutputPort<TextData>_OutputPortId",
                table: "PromptNode");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<ImageData>_OutputPort<ImageData>_OutputPortId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<OptionData>_OutputPort<OptionData>_OutputPortId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticNode<TextData>_OutputPort<TextData>_OutputPortId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropForeignKey(
                name: "FK_SwitchNode_InputPort<OptionData>_InputPortId",
                table: "SwitchNode");

            migrationBuilder.DropIndex(
                name: "IX_SwitchNode_InputPortId",
                table: "SwitchNode");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<TextData>_OutputPortId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<OptionData>_OutputPortId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropIndex(
                name: "IX_StaticNode<ImageData>_OutputPortId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropIndex(
                name: "IX_PromptNode_OutputPortId",
                table: "PromptNode");

            migrationBuilder.DropIndex(
                name: "IX_InteractionNode_OptionOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropIndex(
                name: "IX_InteractionNode_TextInputPortId",
                table: "InteractionNode");

            migrationBuilder.DropIndex(
                name: "IX_InteractionNode_TextOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropIndex(
                name: "IX_InputPort<TextData>_PromptNodeId",
                table: "InputPort<TextData>");

            migrationBuilder.DropColumn(
                name: "InputPortId",
                table: "SwitchNode");

            migrationBuilder.DropColumn(
                name: "OutputPortId",
                table: "StaticNode<TextData>");

            migrationBuilder.DropColumn(
                name: "OutputPortId",
                table: "StaticNode<OptionData>");

            migrationBuilder.DropColumn(
                name: "OutputPortId",
                table: "StaticNode<ImageData>");

            migrationBuilder.DropColumn(
                name: "OutputPortId",
                table: "PromptNode");

            migrationBuilder.DropColumn(
                name: "OptionOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropColumn(
                name: "TextInputPortId",
                table: "InteractionNode");

            migrationBuilder.DropColumn(
                name: "TextOutputPortId",
                table: "InteractionNode");

            migrationBuilder.DropColumn(
                name: "PromptNodeId",
                table: "InputPort<TextData>");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnumId",
                table: "SwitchNode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutputPort<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<TextData>_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InputPort<OptionData>_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<OptionData>_SwitchNode_NodeId",
                table: "InputPort<OptionData>",
                column: "NodeId",
                principalTable: "SwitchNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_InteractionNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputPort<TextData>_PromptNode_NodeId",
                table: "InputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<ImageData>_StaticNode<ImageData>_NodeId",
                table: "OutputPort<ImageData>",
                column: "NodeId",
                principalTable: "StaticNode<ImageData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_InteractionNode_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<OptionData>_StaticNode<OptionData>_NodeId",
                table: "OutputPort<OptionData>",
                column: "NodeId",
                principalTable: "StaticNode<OptionData>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_InteractionNode_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "InteractionNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_PromptNode_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "PromptNode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPort<TextData>_StaticNode<TextData>_NodeId",
                table: "OutputPort<TextData>",
                column: "NodeId",
                principalTable: "StaticNode<TextData>",
                principalColumn: "Id");
        }
    }
}
