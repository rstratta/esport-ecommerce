using ESport.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace ESport.Data.DataAccess
{

    public class ESportDbContext : DbContext
    {

        public ESportDbContext() : base("ESportDb") { }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<ProductFields> ProductFields { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<PointSystemConfiguration> PointSystemConfigurations { get; set; }
        public virtual DbSet<UserContext> UserContext { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureCartItemTable(modelBuilder);
            ConfigUserTable(modelBuilder);
            ConfigureRoleTable(modelBuilder);
            ConfigureCategoryTable(modelBuilder);
            ConfigureProductTable(modelBuilder);
            ConfigureFieldTable(modelBuilder);
            ConfigureProductFieldTable(modelBuilder);
            ConfigureProductImagesTable(modelBuilder);
            ConfigureCartTable(modelBuilder);
            ConfigureReviewTable(modelBuilder);
            ConfigurePointSystemConfigurationTable(modelBuilder);
            ConfigureUserContextTable(modelBuilder);
        }

        private void ConfigureUserContextTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserContext>().
                HasKey(usContext => usContext.Token).
                Property(usContext => usContext.UserId).HasColumnType("varchar").HasMaxLength(50).
                HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UserIdIndex") { IsUnique = true }));
           
        }

        private void ConfigurePointSystemConfigurationTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointSystemConfiguration>().
                HasKey(configuration => configuration.Id).
                Property(configuration => configuration.PropertyName).HasColumnType("varchar").HasMaxLength(50).
                HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("PropertyNameIndex") { IsUnique = true }));
        }

        private void ConfigureProductImagesTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>().
               HasKey(image => new { image.Id, image.ProductId });
        }

        private void ConfigureCartItemTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().
               HasKey(cartItem => cartItem.CartItemId);
        }

        private void ConfigureProductFieldTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFields>().
                HasKey(prodField => new { prodField.ProductId, prodField.FieldId});
        }

        private void ConfigureFieldTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>().
                HasKey(field => field.Id).
                Property(field => field.Name).HasColumnType("varchar").HasMaxLength(50).
                HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("FieldNameIndex") { IsUnique = true }));
        }

        private void ConfigureReviewTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().
                HasKey(review => review.Id);
            modelBuilder.Entity<Review>().
                Property(review => review.ReviewDate).HasColumnType("datetime2");
        }

        private void ConfigureCartTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasKey(cart => cart.CartId);
            modelBuilder.Entity<Cart>().
                Property(cart => cart.Opendate).HasColumnType("datetime2");
            modelBuilder.Entity<Cart>().
                Property(cart => cart.State).HasMaxLength(1);

        }

        private void ConfigureProductTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(product => product.Id).
                Property(p => p.ProductId).HasColumnType("varchar").HasMaxLength(50).
                HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("ProductIdIndex") { IsUnique = true }));
        }

        private void ConfigureCategoryTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(category => category.Id)
                .Property(c => c.CategoryId).HasColumnType("varchar").HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("CategoryIdIndex") { IsUnique = true }));
        }

        private void ConfigureRoleTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(role => role.Id).Property(r => r.RoleId).HasColumnType("varchar").HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("RoleIdIndex") { IsUnique = true }));
        }

        private void ConfigUserTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.Id).
                 Property(u => u.UserId).HasColumnType("varchar").HasMaxLength(50).
                     HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UserIdIndex") { IsUnique = true }));
            modelBuilder.Entity<User>().HasMany<Role>(user => user.Roles)
                      .WithMany(role => role.Users)
                      .Map(cs =>
                      {
                          cs.MapLeftKey("UserId");
                          cs.MapRightKey("RoleId");
                          cs.ToTable("UserRole");
                      });
         }
    }


}
