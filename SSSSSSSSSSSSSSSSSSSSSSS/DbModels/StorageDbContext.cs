using Microsoft.EntityFrameworkCore;

namespace SSSSSSSSSSSSSSSSSSSSSSS.DbModels
{
    public partial class StorageDbContext:DbContext
    {
        private readonly string _connectionString;
        public StorageDbContext() { }

        public StorageDbContext(string connectionString) { _connectionString = connectionString; }
      //  public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options) { } verxnee uproshennoe nijnego s polem

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> 
            optionsBuilder.UseNpgsql(_connectionString)
            .UseLazyLoadingProxies().LogTo(Console.WriteLine);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(x => x.Id).HasName("PK_Product");
                
                e.Property(x=>x.Name).HasColumnName("Name").HasMaxLength(250);
                e.HasOne(x=>x.ProductGroup).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductGroupId);
            
            });
            modelBuilder.Entity<Storage>(e => 
            {
            e.HasKey(x => x.Id).HasName("PK_Storage");
                e.ToTable("Storage");
                e.HasOne(x=>x.Product).WithMany(x=>x.Storages).HasForeignKey(x=>x.ProductId);
            });
            modelBuilder.Entity<ProductGroup>(e => 
            {
            e.HasKey(x => x.Id).HasName("PK_ProductGroup");
                e.ToTable("Category");
                e.Property(x=>x.Name).HasColumnName("Name").HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
