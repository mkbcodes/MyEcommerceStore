using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasmStore.Server.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

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
                name: "IsApplied",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "AddressType",
                table: "UserAddresses",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressType",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "AddressType",
                table: "UserAddresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
