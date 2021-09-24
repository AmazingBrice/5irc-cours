using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSTP3.Migrations
{
    public partial class UpdateConstraintsCompte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 10, 49, 8, 390, DateTimeKind.Local).AddTicks(6713),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2021, 9, 24, 10, 10, 11, 276, DateTimeKind.Local).AddTicks(8455));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 10, 10, 11, 276, DateTimeKind.Local).AddTicks(8455),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2021, 9, 24, 10, 49, 8, 390, DateTimeKind.Local).AddTicks(6713));
        }
    }
}
