namespace Restaurant.Infrastructure.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Restaurant.Core.Entities;

    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext(string connectionString) : base(GetOptions(connectionString)) { }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseOracle(connectionString).Options;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<DiningTable> DiningTables { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "RESTAURANT");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK_CUSTOMER");

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("IDCUSTOMER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.IdBillDetail)
                    .HasName("PK_BILLDETAIL");

                entity.ToTable("BILLDETAIL");

                entity.HasIndex(e => e.IdBill)
                    .HasDatabaseName("FK_BILLDETAIL_BILL");

                entity.HasIndex(e => e.IdFood)
                    .HasDatabaseName("FK_BILLDETAIL_FOOD");

                entity.Property(e => e.IdBillDetail).HasColumnName("IDBILLDETAIL");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.IdBill).HasColumnName("IDBILL");

                entity.Property(e => e.IdFood).HasColumnName("IDFOOD");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,3)");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILLDETAIL_BILL");

                entity.HasOne(d => d.Food)
                     .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.IdFood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILLDETAIL_FOOD");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PK_BILL");

                entity.ToTable("BILL");

                entity.HasIndex(e => e.IdCustomer)
                    .HasDatabaseName("FK_BILL_CUSTOMER");

                entity.HasIndex(e => e.IdDiningTable)
                    .HasDatabaseName("FK_BILL_DININGTABLE");

                entity.HasIndex(e => e.IdWaiter)
                    .HasDatabaseName("FK_BILL_WAITER");

                entity.Property(e => e.IdBill).HasColumnName("IDBILL");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATIONDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.IdCustomer)
                    .IsRequired()
                    .HasColumnName("IDCUSTOMER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdDiningTable).HasColumnName("IDDININGTABLE");

                entity.Property(e => e.IdWaiter).HasColumnName("IDWAITER");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_CUSTOMER");

                entity.HasOne(d => d.DiningTable)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdDiningTable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_DININGTABLE");

                entity.HasOne(d => d.Waiter)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdWaiter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_WAITER");
            });

            modelBuilder.Entity<DiningTable>(entity =>
            {
                entity.HasKey(e => e.IdDiningTable)
                    .HasName("PK_DININGTABLE");

                entity.ToTable("DININGTABLE");

                entity.Property(e => e.IdDiningTable).HasColumnName("IDDININGTABLE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Chairs)
                    .IsRequired()
                    .HasColumnName("CHAIRS")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Reserved)
                    .IsRequired()
                    .HasColumnName("RESERVED")
                    .HasColumnType("CHAR(1)");
            });

            modelBuilder.Entity<Waiter>(entity =>
            {
                entity.HasKey(e => e.IdWaiter)
                    .HasName("PK_WAITER");

                entity.ToTable("WAITER");

                entity.Property(e => e.IdWaiter).HasColumnName("IDWAITER");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnName("ADMISSIONDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age)
                    .HasColumnName("AGE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.IdFood)
                    .HasName("PK_FOOD");

                entity.ToTable("FOOD");

                entity.Property(e => e.IdFood).HasColumnName("IDFOOD");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,3)");
            });

            modelBuilder.HasSequence("SEQ_PK_BILL");

            modelBuilder.HasSequence("SEQ_PK_BILLDETAIL");

            modelBuilder.HasSequence("SEQ_PK_WAITER");

            modelBuilder.HasSequence("SEQ_PK_FOOD");

            modelBuilder.HasSequence("SEQ_PK_DININGTABLE");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
