using Microsoft.EntityFrameworkCore;

namespace WebApi5._0.Data
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<dbGoods> dbGoods { get; set; }
        public DbSet<dbCategory> dbCategories { get; set; }
        public DbSet<dbOrders> dborders { get; set; }
        public DbSet<dbDetailOrder> dbDetailOrders { get; set; }
        public DbSet<dbUser> dbUsers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<dbOrders>(e =>
            {
                e.ToTable("Order");
                e.HasKey(or => or.orderId);
                e.Property(or => or.orderDate).HasDefaultValueSql("getutcdate()");
                e.Property(or => or.consignee).IsRequired().HasMaxLength(100);
                e.HasOne(en => en.user)
                .WithMany(en => en.orders)
                .HasForeignKey(en => en.userId)
                .HasConstraintName("FK_Order_User");
            });
            modelBuilder.Entity<dbDetailOrder>(e =>
            {
                e.ToTable("DetailOrder");
                e.HasKey(dor => new {dor.goodsId, dor.orderId });
                e.HasOne(en => en.dborders)
                .WithMany(en => en.detailorders)
                .HasForeignKey(en => en.orderId)
                .HasConstraintName("FK_DetailOrder_Order");
                e.HasOne(en => en.dbgoods)
                .WithMany(en => en.detailorders)
                .HasForeignKey(en => en.goodsId)
                .HasConstraintName("FK_DetailOrder_Goods");
            });
        }
    }
}
