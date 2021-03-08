using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COBAShop.Data.Migrations
{
    public partial class COBAShop_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7c44c49b-f8c9-4b57-8ec6-f01b3729aba0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "316cfe83-2138-4269-be7d-377dc6cd02f9", "AQAAAAEAACcQAAAAEAvDbinsRa5iw2P8x/v+eTG8h4l+VSVCheZtoOKqz0R1tH+3ZSEEkp0UEPBbmPrrTg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 3, 8, 15, 45, 44, 374, DateTimeKind.Local).AddTicks(9597));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a4ada732-36d9-41c8-84ae-5afc3c819bd2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3bc5deee-8a9a-4799-a229-c70009914a08", "AQAAAAEAACcQAAAAEKBa8lTU33omYMKFJ9mv5QbJS+aAsyy6pfCQQmJROfiUb6EbKn/Eq00mzXNQZD+dsw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 3, 8, 15, 41, 39, 682, DateTimeKind.Local).AddTicks(1328));
        }
    }
}
