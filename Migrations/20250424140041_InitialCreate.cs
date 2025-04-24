using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalProcess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    ParentSectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sectors_Sectors_ParentSectorId",
                        column: x => x.ParentSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserSector",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSector", x => new { x.UserId, x.SectorId });
                    table.ForeignKey(
                        name: "FK_UserSector_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSector_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TemplateDocumentId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessTypes_Documents_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProtocolNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    OriginOrganizationId = table.Column<int>(type: "int", nullable: true),
                    OriginSectorId = table.Column<int>(type: "int", nullable: true),
                    CurrentOrganizationId = table.Column<int>(type: "int", nullable: true),
                    CurrentSectorId = table.Column<int>(type: "int", nullable: true),
                    UserCreateId = table.Column<int>(type: "int", nullable: true),
                    CompletionDeadline = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AccessLevel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_Organizations_CurrentOrganizationId",
                        column: x => x.CurrentOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_Organizations_OriginOrganizationId",
                        column: x => x.OriginOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_ProcessTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProcessTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_Sectors_CurrentSectorId",
                        column: x => x.CurrentSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_Sectors_OriginSectorId",
                        column: x => x.OriginSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Processes_Users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    FromSectorId = table.Column<int>(type: "int", nullable: true),
                    ToSectorId = table.Column<int>(type: "int", nullable: true),
                    MovedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessMovements_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessMovements_Sectors_FromSectorId",
                        column: x => x.FromSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessMovements_Sectors_ToSectorId",
                        column: x => x.ToSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProcessId",
                table: "Documents",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_CurrentOrganizationId",
                table: "Processes",
                column: "CurrentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_CurrentSectorId",
                table: "Processes",
                column: "CurrentSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_OriginOrganizationId",
                table: "Processes",
                column: "OriginOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_OriginSectorId",
                table: "Processes",
                column: "OriginSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_TypeId",
                table: "Processes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_UserCreateId",
                table: "Processes",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessMovements_FromSectorId",
                table: "ProcessMovements",
                column: "FromSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessMovements_ProcessId",
                table: "ProcessMovements",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessMovements_ToSectorId",
                table: "ProcessMovements",
                column: "ToSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTypes_TemplateId",
                table: "ProcessTypes",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_OrganizationId",
                table: "Sectors",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ParentSectorId",
                table: "Sectors",
                column: "ParentSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSector_SectorId",
                table: "UserSector",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Processes_ProcessId",
                table: "Documents",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Processes_ProcessId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "ProcessMovements");

            migrationBuilder.DropTable(
                name: "UserSector");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "ProcessTypes");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
