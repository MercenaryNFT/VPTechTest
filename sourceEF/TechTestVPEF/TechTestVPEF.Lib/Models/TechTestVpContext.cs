using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TechTestVPEF.Data;

public partial class TechTestVpContext : DbContext
{
    private readonly IConfiguration _config;
    public TechTestVpContext(IConfiguration config)
    {
        _config = config;
    }

    public TechTestVpContext(DbContextOptions<TechTestVpContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<VptCustomer> VptCustomers { get; set; }

    public virtual DbSet<VptIncrement> VptIncrements { get; set; }

    public virtual DbSet<VptOrder> VptOrders { get; set; }

    public virtual DbSet<VptOrderLine> VptOrderLines { get; set; }

    public virtual DbSet<VptProduct> VptProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_config.GetConnectionString("DB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VptCustomer>(entity =>
        {
            entity.HasKey(e => e.CusGuid);

            entity.ToTable("vpt_Customer");

            entity.Property(e => e.CusGuid)
                .ValueGeneratedNever()
                .HasComment("Guid")
                .HasColumnName("cus_guid");
            entity.Property(e => e.CusAddress1)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasComment("Address1")
                .HasColumnName("cus_address1");
            entity.Property(e => e.CusAddress2)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasComment("Address2")
                .HasColumnName("cus_address2");
            entity.Property(e => e.CusCountry)
                .HasMaxLength(50)
                .HasComment("Country")
                .HasColumnName("cus_country");
            entity.Property(e => e.CusId)
                .HasMaxLength(25)
                .HasDefaultValueSql("('')")
                .HasComment("Id")
                .HasColumnName("cus_id");
            entity.Property(e => e.CusLastTraded)
                .HasComment("LastTraded")
                .HasColumnType("datetime")
                .HasColumnName("cus_last_traded");
            entity.Property(e => e.CusName)
                .HasMaxLength(100)
                .HasComment("Name")
                .HasColumnName("cus_name");
            entity.Property(e => e.CusPostcode)
                .HasMaxLength(10)
                .HasDefaultValueSql("('')")
                .HasComment("Postcode")
                .HasColumnName("cus_postcode");
            entity.Property(e => e.CusTown)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasComment("Town")
                .HasColumnName("cus_town");
        });

        modelBuilder.Entity<VptIncrement>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("vpt_Increment");

            entity.Property(e => e.IncLastId).HasColumnName("inc_last_id");
            entity.Property(e => e.IncName)
                .HasMaxLength(50)
                .HasColumnName("inc_name");
            entity.Property(e => e.IncPrefix)
                .HasMaxLength(10)
                .HasColumnName("inc_prefix");
        });

        modelBuilder.Entity<VptOrder>(entity =>
        {
            entity.HasKey(e => e.OrdGuid);

            entity.ToTable("vpt_Order");

            entity.Property(e => e.OrdGuid)
                .ValueGeneratedNever()
                .HasComment("Guid")
                .HasColumnName("ord_guid");
            entity.Property(e => e.OrdCreated)
                .HasComment("Created")
                .HasColumnType("datetime")
                .HasColumnName("ord_created");
            entity.Property(e => e.OrdCusGuid)
                .HasComment("CustomerGuid")
                .HasColumnName("ord_cus_guid");
            entity.Property(e => e.OrdCustomerRef)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasComment("CustomerRef")
                .HasColumnName("ord_customer_ref");
            entity.Property(e => e.OrdOrderNum)
                .HasComment("OrderNumber")
                .HasColumnName("ord_order_num");
            entity.Property(e => e.OrdRequiredDate)
                .HasComment("RequiredDate")
                .HasColumnType("datetime")
                .HasColumnName("ord_required_date");
            entity.Property(e => e.OrderIsShipped)
                .HasComment("IsShipped")
                .HasColumnName("order_is_shipped");

            entity.HasOne(d => d.OrdCus).WithMany(p => p.VptOrders)
                .HasForeignKey(d => d.OrdCusGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vpt_Customer_vpt_Order");
        });

        modelBuilder.Entity<VptOrderLine>(entity =>
        {
            entity.HasKey(e => e.OrlGuid);

            entity.ToTable("vpt_Order_Line");

            entity.Property(e => e.OrlGuid)
                .ValueGeneratedNever()
                .HasComment("Guid")
                .HasColumnName("orl_guid");
            entity.Property(e => e.OrlOrdGuid)
                .HasComment("OrderGuid")
                .HasColumnName("orl_ord_guid");
            entity.Property(e => e.OrlPrdGuid)
                .HasComment("ProductGuid")
                .HasColumnName("orl_prd_guid");
            entity.Property(e => e.OrlPrice)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Price")
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("orl_price");
            entity.Property(e => e.OrlQty)
                .HasComment("Qty")
                .HasColumnName("orl_qty");
            entity.Property(e => e.OrlUom)
                .HasMaxLength(10)
                .HasDefaultValueSql("('')")
                .HasComment("UOM")
                .HasColumnName("orl_uom");

            entity.HasOne(d => d.OrlOrd).WithMany(p => p.VptOrderLines)
                .HasForeignKey(d => d.OrlOrdGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vpt_Order_Line_vpt_Order");

            entity.HasOne(d => d.OrlPrd).WithMany(p => p.VptOrderLines)
                .HasForeignKey(d => d.OrlPrdGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vpt_Order_Line_vpt_Product");
        });

        modelBuilder.Entity<VptProduct>(entity =>
        {
            entity.HasKey(e => e.PrdGuid);

            entity.ToTable("vpt_Product");

            entity.Property(e => e.PrdGuid)
                .ValueGeneratedNever()
                .HasComment("Guid")
                .HasColumnName("prd_guid");
            entity.Property(e => e.PrdCost)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Cost")
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("prd_cost");
            entity.Property(e => e.PrdDescription)
                .HasComment("Description")
                .HasColumnName("prd_description");
            entity.Property(e => e.PrdId)
                .HasMaxLength(50)
                .HasComment("Id")
                .HasColumnName("prd_id");
            entity.Property(e => e.PrdPrice)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Price")
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("prd_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
