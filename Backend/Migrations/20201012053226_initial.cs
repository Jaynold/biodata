using Microsoft.EntityFrameworkCore.Migrations;

namespace BioData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biodata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Homepage = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biodata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tool = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    BiodataId = table.Column<string>(type: "nvarchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BiodataLanguage",
                columns: table => new
                {
                    BiodataId = table.Column<string>(type: "nvarchar(90)", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiodataLanguage", x => new { x.BiodataId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_BiodataLanguage_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiodataLanguage_Language_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiodataOperatingSystem",
                columns: table => new
                {
                    BiodataId = table.Column<string>(type: "nvarchar(90)", nullable: false),
                    OperatingSystemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiodataOperatingSystem", x => new { x.BiodataId, x.OperatingSystemsId });
                    table.ForeignKey(
                        name: "FK_BiodataOperatingSystem_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiodataOperatingSystem_OperatingSystem_OperatingSystemsId",
                        column: x => x.OperatingSystemsId,
                        principalTable: "OperatingSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiodataToolType",
                columns: table => new
                {
                    BiodataId = table.Column<string>(type: "nvarchar(90)", nullable: false),
                    ToolTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiodataToolType", x => new { x.BiodataId, x.ToolTypesId });
                    table.ForeignKey(
                        name: "FK_BiodataToolType_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiodataToolType_ToolType_ToolTypesId",
                        column: x => x.ToolTypesId,
                        principalTable: "ToolType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkLinkType",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    LinkTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkLinkType", x => new { x.LinkId, x.LinkTypesId });
                    table.ForeignKey(
                        name: "FK_LinkLinkType_Link_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkLinkType_LinkType_LinkTypesId",
                        column: x => x.LinkTypesId,
                        principalTable: "LinkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiodataLanguage_LanguagesId",
                table: "BiodataLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_BiodataOperatingSystem_OperatingSystemsId",
                table: "BiodataOperatingSystem",
                column: "OperatingSystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_BiodataToolType_ToolTypesId",
                table: "BiodataToolType",
                column: "ToolTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_BiodataId",
                table: "Link",
                column: "BiodataId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkLinkType_LinkTypesId",
                table: "LinkLinkType",
                column: "LinkTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiodataLanguage");

            migrationBuilder.DropTable(
                name: "BiodataOperatingSystem");

            migrationBuilder.DropTable(
                name: "BiodataToolType");

            migrationBuilder.DropTable(
                name: "LinkLinkType");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "OperatingSystem");

            migrationBuilder.DropTable(
                name: "ToolType");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "LinkType");

            migrationBuilder.DropTable(
                name: "Biodata");
        }
    }
}
