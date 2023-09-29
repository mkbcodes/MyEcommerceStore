using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasmStore.Server.Migrations
{
    public partial class ReportModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a667b4e-965b-4921-bc1b-0bae6a1a1d68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7be915a5-ff25-4bb9-aa01-23606f85ebce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc802c83-f1d4-4f2a-a35a-c70a06e46937"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("30c62d9c-d226-49ed-849e-bfb2207fb607"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d52f42b7-42fa-429f-b2fd-ecf4a41716fd"));

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimePeriodEnd",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimePeriodStart",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRevenue",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTax",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Images",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("a6c4719a-cbd3-47d9-b5f3-e5b78a961880"), new DateTime(2023, 9, 29, 1, 39, 52, 265, DateTimeKind.Utc).AddTicks(328), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description2", "Seasonal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("c46f7870-3851-4a9c-b868-ea3068346749"), new DateTime(2023, 9, 29, 1, 39, 52, 265, DateTimeKind.Utc).AddTicks(324), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description1", "Macrame" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("3caff9fd-da32-4d8e-ae8d-940384d30912"), new Guid("c46f7870-3851-4a9c-b868-ea3068346749"), new DateTime(2023, 9, 29, 1, 39, 52, 265, DateTimeKind.Utc).AddTicks(488), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Never confuse your basil with your parsley again with our delightful Vegetable Garden Markers! These charming ornaments are designed to bring both flair and functionality to your vegetable garden. Each marker features a beautifully crafted, weather-resistant design that not only labels your plants but also adds a whimsical touch to your garden.", null, "Vegetable Garden Marker", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("471d6cb7-1c12-4163-9759-a7a228d6eb21"), new Guid("c46f7870-3851-4a9c-b868-ea3068346749"), new DateTime(2023, 9, 29, 1, 39, 52, 265, DateTimeKind.Utc).AddTicks(472), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elevate your living space with our ethereal Woven Wall Hanging in Macrame! Meticulously handcrafted by skilled artisans, this wall hanging is the epitome of bohemian elegance. Featuring intricate patterns and soft, earthy hues, our macrame wall hanging effortlessly adds texture and charm to any room. Made from 100% premium cotton, it's not just an art piece but a testament to craftsmanship and sustainability.", null, "Woven Wall Hanging", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("49e8432f-c40f-40f4-a1aa-dbf26848cefa"), new Guid("a6c4719a-cbd3-47d9-b5f3-e5b78a961880"), new DateTime(2023, 9, 29, 1, 39, 52, 265, DateTimeKind.Utc).AddTicks(504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add a dash of romance and elegance to your special day with our Wedding Wall Accent in Embroidery and Decorative elements. This exquisite wall art piece is a perfect backdrop for wedding photos or a focal point in the wedding venue. Created with intricate embroidery work and delicate decorative embellishments, this wall accent captures the essence of love and union in its design.", null, "Wall Accent", 9.99m, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_OrderId",
                table: "Reports",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Orders_OrderId",
                table: "Reports",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Orders_OrderId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_OrderId",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3caff9fd-da32-4d8e-ae8d-940384d30912"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("471d6cb7-1c12-4163-9759-a7a228d6eb21"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49e8432f-c40f-40f4-a1aa-dbf26848cefa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6c4719a-cbd3-47d9-b5f3-e5b78a961880"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c46f7870-3851-4a9c-b868-ea3068346749"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TimePeriodEnd",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TimePeriodStart",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Reports",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportType",
                table: "Reports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimePeriod",
                table: "Reports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("30c62d9c-d226-49ed-849e-bfb2207fb607"), new DateTime(2023, 9, 23, 12, 21, 34, 287, DateTimeKind.Utc).AddTicks(3115), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description2", "Seasonal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("d52f42b7-42fa-429f-b2fd-ecf4a41716fd"), new DateTime(2023, 9, 23, 12, 21, 34, 287, DateTimeKind.Utc).AddTicks(3091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description1", "Macrame" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("3a667b4e-965b-4921-bc1b-0bae6a1a1d68"), new Guid("d52f42b7-42fa-429f-b2fd-ecf4a41716fd"), new DateTime(2023, 9, 23, 12, 21, 34, 287, DateTimeKind.Utc).AddTicks(3270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elevate your living space with our ethereal Woven Wall Hanging in Macrame! Meticulously handcrafted by skilled artisans, this wall hanging is the epitome of bohemian elegance. Featuring intricate patterns and soft, earthy hues, our macrame wall hanging effortlessly adds texture and charm to any room. Made from 100% premium cotton, it's not just an art piece but a testament to craftsmanship and sustainability.", null, "Woven Wall Hanging", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("7be915a5-ff25-4bb9-aa01-23606f85ebce"), new Guid("30c62d9c-d226-49ed-849e-bfb2207fb607"), new DateTime(2023, 9, 23, 12, 21, 34, 287, DateTimeKind.Utc).AddTicks(3284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add a dash of romance and elegance to your special day with our Wedding Wall Accent in Embroidery and Decorative elements. This exquisite wall art piece is a perfect backdrop for wedding photos or a focal point in the wedding venue. Created with intricate embroidery work and delicate decorative embellishments, this wall accent captures the essence of love and union in its design.", null, "Wall Accent", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "Image", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("fc802c83-f1d4-4f2a-a35a-c70a06e46937"), new Guid("d52f42b7-42fa-429f-b2fd-ecf4a41716fd"), new DateTime(2023, 9, 23, 12, 21, 34, 287, DateTimeKind.Utc).AddTicks(3281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Never confuse your basil with your parsley again with our delightful Vegetable Garden Markers! These charming ornaments are designed to bring both flair and functionality to your vegetable garden. Each marker features a beautifully crafted, weather-resistant design that not only labels your plants but also adds a whimsical touch to your garden.", null, "Vegetable Garden Marker", 9.99m, 10 });
        }
    }
}
