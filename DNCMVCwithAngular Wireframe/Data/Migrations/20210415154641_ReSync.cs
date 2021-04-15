using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DNCMVCwithAngular_Wireframe.Migrations
{
    public partial class ReSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 4, 15, 15, 46, 40, 970, DateTimeKind.Utc).AddTicks(9728));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 4, 14, 15, 59, 11, 8, DateTimeKind.Utc).AddTicks(7052));
        }
    }
}
