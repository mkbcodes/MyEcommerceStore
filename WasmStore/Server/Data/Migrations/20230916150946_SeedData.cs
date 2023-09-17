using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasmStore.Server.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Description1", "Category1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Description2", "Category2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { 1, 1, "Elevate your living space with our ethereal Woven Wall Hanging in Macrame! Meticulously handcrafted by skilled artisans, this wall hanging is the epitome of bohemian elegance. Featuring intricate patterns and soft, earthy hues, our macrame wall hanging effortlessly adds texture and charm to any room. Made from 100% premium cotton, it's not just an art piece but a testament to craftsmanship and sustainability.", "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg", "Woven Wall Hanging", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { 2, 2, "Never confuse your basil with your parsley again with our delightful Vegetable Garden Markers! These charming ornaments are designed to bring both flair and functionality to your vegetable garden. Each marker features a beautifully crafted, weather-resistant design that not only labels your plants but also adds a whimsical touch to your garden.", "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg", "Vegetable Garden Marker", 9.99m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[] { 3, 2, "Add a dash of romance and elegance to your special day with our Wedding Wall Accent in Embroidery and Decorative elements. This exquisite wall art piece is a perfect backdrop for wedding photos or a focal point in the wedding venue. Created with intricate embroidery work and delicate decorative embellishments, this wall accent captures the essence of love and union in its design.", "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg", "Wall Accent", 9.99m, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
