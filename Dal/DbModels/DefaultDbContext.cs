using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Courier> Couriers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DosageForm> DosageForms { get; set; }

    public virtual DbSet<DrugType> DrugTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<ItemsInOrder> ItemsInOrders { get; set; }

    public virtual DbSet<ItemsSupply> ItemsSupplies { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineDiscount> MedicineDiscounts { get; set; }

    public virtual DbSet<MedicineReview> MedicineReviews { get; set; }

    public virtual DbSet<MedicineSupplier> MedicineSuppliers { get; set; }

    public virtual DbSet<MedicineType> MedicineTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<StorageRule> StorageRules { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }
	public virtual DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-HP\\SQLEXPRESS;Initial Catalog=db3;Integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_cour");

            entity.ToTable("couriers");

            entity.Property(e => e.EmploymentDate).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_cust");

            entity.ToTable("customers");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_deliv");

            entity.ToTable("deliveries");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CourierId).HasColumnName("CourierID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Delivery)
                .HasForeignKey<Delivery>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__deliveries__Id__0F2D40CE");

            entity.HasOne(d => d.Id1).WithOne(p => p.Delivery)
                .HasForeignKey<Delivery>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__deliveries__Id__0E391C95");

            entity.HasOne(d => d.Id2).WithOne(p => p.Delivery)
                .HasForeignKey<Delivery>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__deliveries__Id__10216507");
        });

        modelBuilder.Entity<DosageForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dosfor");

            entity.ToTable("dosage_forms");

            entity.Property(e => e.FormName).HasMaxLength(255);
        });

        modelBuilder.Entity<DrugType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_drugtype");

            entity.ToTable("drug_types");

            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_empl");

            entity.ToTable("employees");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__Id__04AFB25B");
        });

        modelBuilder.Entity<EmployeeAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_empatten");

            entity.ToTable("employee_attendance");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.EmployeeAttendance)
                .HasForeignKey<EmployeeAttendance>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee_att__Id__05A3D694");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_emprol");

            entity.ToTable("employee_roles");

            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<EmployeeTraining>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_emptrain");

            entity.ToTable("employee_trainings");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TrainingTopic).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.EmployeeTraining)
                .HasForeignKey<EmployeeTraining>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee_tra__Id__14E61A24");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_equ");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentName).HasMaxLength(255);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_instr");

            entity.ToTable("instruments");

            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.InstrumentName).HasMaxLength(255);
        });

        modelBuilder.Entity<ItemsInOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_inteminord");

            entity.ToTable("items_in_order");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ItemsInOrder)
                .HasForeignKey<ItemsInOrder>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items_in_ord__Id__13F1F5EB");

            entity.HasOne(d => d.Id1).WithOne(p => p.ItemsInOrder)
                .HasForeignKey<ItemsInOrder>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items_in_ord__Id__12FDD1B2");
        });

        modelBuilder.Entity<ItemsSupply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_itemssupp");

            entity.ToTable("items_supply");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.MedicineSupplierId).HasColumnName("MedicineSupplierID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ItemsSupply)
                .HasForeignKey<ItemsSupply>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items_supply__Id__02C769E9");

            entity.HasOne(d => d.Id1).WithOne(p => p.ItemsSupply)
                .HasForeignKey<ItemsSupply>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__items_supply__Id__01D345B0");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_manufac");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Address).HasColumnType("ntext");
            entity.Property(e => e.ManufacturerName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medicat");

            entity.ToTable("medications");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DrugTypeId).HasColumnName("DrugTypeID");
            entity.Property(e => e.FormId).HasColumnName("FormID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Medication)
                .HasForeignKey<Medication>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medications__Id__0C50D423");

            entity.HasOne(d => d.Id1).WithOne(p => p.Medication)
                .HasForeignKey<Medication>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medications__Id__0D44F85C");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medicin");

            entity.ToTable("medicines");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.MedicineName).HasMaxLength(255);
            entity.Property(e => e.PrescriptionStatusName).HasMaxLength(255);
            entity.Property(e => e.StorageRuleId).HasColumnName("StorageRuleID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Medicine)
                .HasForeignKey<Medicine>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicines__Id__0880433F");

            entity.HasOne(d => d.Id1).WithOne(p => p.Medicine)
                .HasForeignKey<Medicine>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicines__Id__0697FACD");

            entity.HasOne(d => d.Id2).WithOne(p => p.Medicine)
                .HasForeignKey<Medicine>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicines__Id__078C1F06");
        });

        modelBuilder.Entity<MedicineDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_meddisc");

            entity.ToTable("medicine_discounts");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.MedicineDiscount)
                .HasForeignKey<MedicineDiscount>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_dis__Id__15DA3E5D");
        });

        modelBuilder.Entity<MedicineReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medrev");

            entity.ToTable("medicine_reviews");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");
            entity.Property(e => e.ReviewText).HasColumnType("ntext");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.MedicineReview)
                .HasForeignKey<MedicineReview>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_rev__Id__00DF2177");

            entity.HasOne(d => d.Id1).WithOne(p => p.MedicineReview)
                .HasForeignKey<MedicineReview>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_rev__Id__16CE6296");
        });

        modelBuilder.Entity<MedicineSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medsupp");

            entity.ToTable("medicine_suppliers");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplyDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.MedicineSupplier)
                .HasForeignKey<MedicineSupplier>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_sup__Id__03BB8E22");
        });

        modelBuilder.Entity<MedicineType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_medtypes");

            entity.ToTable("medicine_types");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.TypeName).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.MedicineType)
                .HasForeignKey<MedicineType>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_typ__Id__09746778");

            entity.HasOne(d => d.Id1).WithOne(p => p.MedicineType)
                .HasForeignKey<MedicineType>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_typ__Id__0A688BB1");

            entity.HasOne(d => d.Id2).WithOne(p => p.MedicineType)
                .HasForeignKey<MedicineType>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicine_typ__Id__0B5CAFEA");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__Id__11158940");

            entity.HasOne(d => d.Id1).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__Id__1209AD79");
        });

        modelBuilder.Entity<StorageRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_storrul");

            entity.ToTable("storage_rules");

            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.RuleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_supp");

            entity.ToTable("suppliers");

            entity.Property(e => e.Address).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
