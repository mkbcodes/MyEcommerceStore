using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WasmStore.Server.Models;
using WasmStore.Shared;
using static Duende.IdentityServer.Models.IdentityResources;

namespace WasmStore.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public DbSet<Product>? Products { get; set; }
        public DbSet<Shared.Address>? Addresses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Favourite>? Favourites { get; set; }

        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<ProductTag>? ProductTags { get; set; }
        public DbSet<Report>? Reports { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<UserAddress>? UserAddresses { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category1", Description = "Description1" },
                new Category { Id = 2, Name = "Category2", Description = "Description2" }
            // Add more categories as needed
            );

                    // seed data for sample entity
                    modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Woven Wall Hanging",
                Description = "Elevate your living space with our ethereal Woven Wall Hanging in Macrame! Meticulously handcrafted by skilled artisans, this wall hanging is the epitome of bohemian elegance. Featuring intricate patterns and soft, earthy hues, our macrame wall hanging effortlessly adds texture and charm to any room. Made from 100% premium cotton, it's not just an art piece but a testament to craftsmanship and sustainability.",
                Price = 9.99m,
                ImageUrl = "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg",
                CategoryId = 1, // Set the appropriate CategoryId
                StockQuantity = 10
            },
            new Product
            {
                Id = 2,
                Name = "Vegetable Garden Marker",
                Description = "Never confuse your basil with your parsley again with our delightful Vegetable Garden Markers! These charming ornaments are designed to bring both flair and functionality to your vegetable garden. Each marker features a beautifully crafted, weather-resistant design that not only labels your plants but also adds a whimsical touch to your garden.",
                Price = 9.99m,
                ImageUrl = "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg",
                CategoryId = 2, // Set the appropriate CategoryId
                StockQuantity = 10
            },
            new Product
            {
                Id = 3,
                Name = "Wall Accent",
                Description = "Add a dash of romance and elegance to your special day with our Wedding Wall Accent in Embroidery and Decorative elements. This exquisite wall art piece is a perfect backdrop for wedding photos or a focal point in the wedding venue. Created with intricate embroidery work and delicate decorative embellishments, this wall accent captures the essence of love and union in its design.",
                Price = 9.99m,
                ImageUrl = "https://garrettmuseumofart.org/wp-content/uploads/2016/03/placeholder_template.jpg",
                CategoryId = 2, // Set the appropriate CategoryId
                StockQuantity = 10
            }
        );


            // User Configuration
            modelBuilder.Entity<AppUser>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Address Configuration
            modelBuilder.Entity<Shared.Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Shared.Address>()
                .Property(a => a.AddressLine)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Shared.Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Shared.Address>()
                .Property(a => a.Province)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Shared.Address>()
                .Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Shared.Address>()
                .Property(a => a.PostalCode)
                .HasMaxLength(50);

            // UserAddress Configuration
            modelBuilder.Entity<UserAddress>()
                .HasKey(ua => ua.Id);

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ua => ua.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a User doesn't delete associated UserAddresses

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses) // Assuming Address entity has a collection property named UserAddresses
                .HasForeignKey(ua => ua.AddressId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting an Address doesn't delete associated UserAddresses

            modelBuilder.Entity<UserAddress>()
                .Property(ua => ua.AddressType)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Product doesn't delete associated ProductTags

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Tag doesn't delete associated ProductTags

            // Favourite Configuration
            modelBuilder.Entity<Favourite>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.AppUser)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a User doesn't delete associated Favourites

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Product)
                .WithMany(p => p.Favourites)
                .HasForeignKey(f => f.ProductId);

            // ProductTag Configuration
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Product doesn't delete associated ProductTags

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            // Tag Configuration
            modelBuilder.Entity<Tag>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Tag>()
                .Property(t => t.Description)
                .HasMaxLength(1000);

            // Category Configuration
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(1000);

            // Product Configuration
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Category doesn't delete associated Products

            // Order Configuration
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.AppUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a User doesn't delete associated Orders

            modelBuilder.Entity<Order>()
                .Property(o => o.Discount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Tax)
                .HasColumnType("decimal(18,2)");


            // OrderItem Configuration
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting an Order doesn't delete associated OrderItems

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Product doesn't delete associated OrderItems

            // ShoppingCart Configuration
            modelBuilder.Entity<ShoppingCart>()
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.AppUser)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(sc => sc.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a User doesn't delete associated ShoppingCarts


            // CartItem Configuration
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(sc => sc.CartItems)
                .HasForeignKey(ci => ci.ShoppingCartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId);

            // Payment Configuration
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId);

            // Review Configuration
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.AppUser)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a User doesn't delete associated Reviews

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // This ensures that deleting a Product doesn't delete associated Reviews

            // Report Configuration
            modelBuilder.Entity<Report>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.AppUser)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


        }


    }
}
