using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kirby.Migrations
{
    public partial class establishKirbyDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "formulas",
                columns: table => new
                {
                    formulaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    arm = table.Column<float>(nullable: false),
                    cuff = table.Column<float>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    neck = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formulas", x => x.formulaId);
                });

            migrationBuilder.CreateTable(
                name: "needles",
                columns: table => new
                {
                    needleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    brand = table.Column<string>(nullable: true),
                    line = table.Column<string>(nullable: true),
                    material = table.Column<string>(nullable: true),
                    mmSize = table.Column<float>(nullable: false),
                    product = table.Column<string>(nullable: true),
                    style = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_needles", x => x.needleId);
                });

            migrationBuilder.CreateTable(
                name: "patterns",
                columns: table => new
                {
                    patternId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patterns", x => x.patternId);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    sizeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    bust = table.Column<float>(nullable: false),
                    cuff = table.Column<float>(nullable: false),
                    hip = table.Column<float>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    neck = table.Column<float>(nullable: false),
                    sleeveLen = table.Column<float>(nullable: false),
                    torso = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "yarns",
                columns: table => new
                {
                    yarnId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    brand = table.Column<string>(nullable: true),
                    line = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    product = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yarns", x => x.yarnId);
                });

            migrationBuilder.CreateTable(
                name: "swatches",
                columns: table => new
                {
                    swatchId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    length = table.Column<float>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    needleId = table.Column<int>(nullable: true),
                    rows = table.Column<int>(nullable: false),
                    stitches = table.Column<int>(nullable: false),
                    width = table.Column<float>(nullable: false),
                    yarnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_swatches", x => x.swatchId);
                    table.ForeignKey(
                        name: "FK_swatches_needles_needleId",
                        column: x => x.needleId,
                        principalTable: "needles",
                        principalColumn: "needleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_swatches_yarns_yarnId",
                        column: x => x.yarnId,
                        principalTable: "yarns",
                        principalColumn: "yarnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sweaters",
                columns: table => new
                {
                    sweaterId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    formulaId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    patternId = table.Column<int>(nullable: true),
                    recipient = table.Column<string>(nullable: true),
                    sizeId = table.Column<int>(nullable: true),
                    swatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sweaters", x => x.sweaterId);
                    table.ForeignKey(
                        name: "FK_sweaters_formulas_formulaId",
                        column: x => x.formulaId,
                        principalTable: "formulas",
                        principalColumn: "formulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sweaters_patterns_patternId",
                        column: x => x.patternId,
                        principalTable: "patterns",
                        principalColumn: "patternId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sweaters_sizes_sizeId",
                        column: x => x.sizeId,
                        principalTable: "sizes",
                        principalColumn: "sizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sweaters_swatches_swatchId",
                        column: x => x.swatchId,
                        principalTable: "swatches",
                        principalColumn: "swatchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_swatches_needleId",
                table: "swatches",
                column: "needleId");

            migrationBuilder.CreateIndex(
                name: "IX_swatches_yarnId",
                table: "swatches",
                column: "yarnId");

            migrationBuilder.CreateIndex(
                name: "IX_sweaters_formulaId",
                table: "sweaters",
                column: "formulaId");

            migrationBuilder.CreateIndex(
                name: "IX_sweaters_patternId",
                table: "sweaters",
                column: "patternId");

            migrationBuilder.CreateIndex(
                name: "IX_sweaters_sizeId",
                table: "sweaters",
                column: "sizeId");

            migrationBuilder.CreateIndex(
                name: "IX_sweaters_swatchId",
                table: "sweaters",
                column: "swatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sweaters");

            migrationBuilder.DropTable(
                name: "formulas");

            migrationBuilder.DropTable(
                name: "patterns");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "swatches");

            migrationBuilder.DropTable(
                name: "needles");

            migrationBuilder.DropTable(
                name: "yarns");
        }
    }
}
