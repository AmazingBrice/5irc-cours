using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace APITP3.Migrations
{
    public partial class CreationBDFilmRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "T_E_COMPTE_CPT",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPT_NOM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_PRENOM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_TELPORTABLE = table.Column<string>(type: "char(10)", nullable: true),
                    CPT_MEL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPT_PWD = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    CPT_RUE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CPT_CP = table.Column<string>(type: "char(5)", nullable: false),
                    CPT_VILLE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_PAYS = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "France"),
                    CPT_LATITUDE = table.Column<float>(type: "real", nullable: true),
                    CPT_LONGITUDE = table.Column<float>(type: "real", nullable: true),
                    CPT_DATECREATION = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2021, 9, 24, 10, 10, 11, 276, DateTimeKind.Local).AddTicks(8455))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_COMPTE_CPT", x => x.CPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_E_FILM_FLM",
                schema: "public",
                columns: table => new
                {
                    FLM_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FLM_TITRE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FLM_SYNOPSIS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FLM_DATEPARUTION = table.Column<DateTime>(type: "date", nullable: false),
                    FLM_DUREE = table.Column<decimal>(type: "numeric", nullable: false),
                    FLM_GENRE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FLM_URLPHOTO = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_FILM_FLM", x => x.FLM_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_J_FAVORI_FAV",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(type: "integer", nullable: false),
                    FLM_ID = table.Column<int>(type: "integer", nullable: false),
                    FAV_COMMENTAIRE = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Compte = table.Column<int>(type: "integer", nullable: true),
                    Film = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAV", x => new { x.FLM_ID, x.CPT_ID });
                    table.ForeignKey(
                        name: "FK_FAV_CPT",
                        column: x => x.CPT_ID,
                        principalSchema: "public",
                        principalTable: "T_E_COMPTE_CPT",
                        principalColumn: "CPT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAV_FLM",
                        column: x => x.FLM_ID,
                        principalSchema: "public",
                        principalTable: "T_E_FILM_FLM",
                        principalColumn: "FLM_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_E_COMPTE_CPT_CPT_MEL",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                column: "CPT_MEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_J_FAVORI_FAV_CPT_ID",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                column: "CPT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_J_FAVORI_FAV",
                schema: "public");

            migrationBuilder.DropTable(
                name: "T_E_COMPTE_CPT",
                schema: "public");

            migrationBuilder.DropTable(
                name: "T_E_FILM_FLM",
                schema: "public");
        }
    }
}
