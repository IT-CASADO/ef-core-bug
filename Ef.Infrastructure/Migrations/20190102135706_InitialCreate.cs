using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ef.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PlanningEngine");

            migrationBuilder.CreateTable(
                name: "Attribute",
                schema: "PlanningEngine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    RoadmapId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Formula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_Attribute_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "PlanningEngine",
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeFormulaVariableAttribute",
                schema: "PlanningEngine",
                columns: table => new
                {
                    AttributeId = table.Column<Guid>(nullable: false),
                    VariableAttributeId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeFormulaVariableAttribute", x => new { x.AttributeId, x.VariableAttributeId });
                    table.ForeignKey(
                        name: "FK_AttributeFormulaVariableAttribute_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "PlanningEngine",
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_ParentId",
                schema: "PlanningEngine",
                table: "Attribute",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeFormulaVariableAttribute",
                schema: "PlanningEngine");

            migrationBuilder.DropTable(
                name: "Attribute",
                schema: "PlanningEngine");
        }
    }
}
