using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Models;

namespace SRW_Backend_API.Data
{
    public partial class SRWVirtualHubDbContext : DbContext
    {
        public DbSet<Assistance> Assistances { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ResourceTag> ResourceTags { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<OpportunityType> OpportunityTypes { get; set; }
        public DbSet<Opportunity> Opportunitys { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<DatasetType> DatasetTypes { get; set; }
        public DbSet<Dataset> Datasets { get; set; }

        public SRWVirtualHubDbContext(DbContextOptions<SRWVirtualHubDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assistance>(entity =>
            {
                entity.ToTable("Assistance", "dbo");
                entity.HasKey(e => e.Assistance_ID);

                entity.Property(e => e.Assistance_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Assistance_First_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Assistance_Last_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Assistance_Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Assistance_Phone)
                    .HasMaxLength(100);

                entity.Property(e => e.Assistance_Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Assistance_Resolved)
                .IsRequired()
                .HasDefaultValue(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image", "dbo");
                entity.HasKey(e => e.Image_ID);

                entity.Property(e => e.Image_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Image_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Image_Address)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "dbo");
                entity.HasKey(e => e.Location_ID);

                entity.Property(e => e.Location_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Location_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_County)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_State)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location_Zip)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource", "dbo");
                entity.HasKey(e => e.Resource_ID);

                entity.Property(e => e.Resource_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Resource_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Resource_Phone)
                    .HasMaxLength(100);

                entity.Property(e => e.Resource_Website)
                    .HasMaxLength(100);

                entity.Property(e => e.Resource_Eligibility)
                    .HasMaxLength(100);

                entity.Property(e => e.Resource_Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);

                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.Location_ID)
                    .IsRequired(false);
            });

            modelBuilder.Entity<ResourceTag>(entity =>
            {
                entity.ToTable("ResourceTag", "dbo");
                entity.HasKey(e => new { e.Resource_ID, e.Tag_ID });

                entity.HasOne(e => e.Resource)
                    .WithMany()
                    .HasForeignKey(e => e.Resource_ID);

                entity.HasOne(e => e.Tag)
                    .WithMany()
                    .HasForeignKey(e => e.Tag_ID);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "dbo");
                entity.HasKey(e => e.Tag_ID);

                entity.Property(e => e.Tag_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Tag_Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("Function", "dbo");
                entity.HasKey(e => e.Function_ID);

                entity.Property(e => e.Function_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Function_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Function_Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Function_Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");
                entity.HasKey(e => e.User_ID);

                entity.Property(e => e.User_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.User_First_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.User_Last_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.User_Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.User_Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.User_Password)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "dbo");
                entity.HasKey(e => e.Role_ID);

                entity.Property(e => e.Role_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Role_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Role_Description)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "dbo");
                entity.HasKey(e => new { e.User_ID, e.Role_ID });

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_ID);

                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.Role_ID);
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType", "dbo");
                entity.HasKey(e => e.RoomType_ID);

                entity.Property(e => e.RoomType_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoomType_Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "dbo");
                entity.HasKey(e => e.Room_ID);

                entity.Property(e => e.Room_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Room_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Room_Number)
                    .IsRequired(false);

                entity.Property(e => e.Room_Floor)
                    .IsRequired();

                entity.Property(e => e.Room_Description)
                    .HasMaxLength(500);

                entity.HasOne(e => e.RoomType)
                    .WithMany()
                    .HasForeignKey(e => e.RoomType_ID);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);
            });

            modelBuilder.Entity<UserRoom>(entity =>
            {
                entity.ToTable("UserRoom", "dbo");
                entity.HasKey(e => new { e.User_ID, e.Room_ID });

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_ID);

                entity.HasOne(e => e.Room)
                    .WithMany()
                    .HasForeignKey(e => e.Room_ID);
            });

            modelBuilder.Entity<OpportunityType>(entity =>
            {
                entity.ToTable("OpportunityType", "dbo");
                entity.HasKey(e => e.OpportunityType_ID);

                entity.Property(e => e.OpportunityType_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OpportunityType_Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.ToTable("Opportunity", "dbo");
                entity.HasKey(e => e.Opportunity_ID);

                entity.Property(e => e.Opportunity_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Opportunity_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Opportunity_Email)
                    .HasMaxLength(100);

                entity.Property(e => e.Opportunity_Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.Opportunity_Start_Date)
                    .IsRequired(false);

                entity.Property(e => e.Opportunity_End_Date)
                    .IsRequired(false);

                entity.Property(e => e.Opportunity_Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(e => e.OpportunityType)
                    .WithMany()
                    .HasForeignKey(e => e.OpportunityType_ID);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);

                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.Location_ID);

                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.Role_ID);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("Equipment", "dbo");
                entity.HasKey(e => e.Equipment_ID);

                entity.Property(e => e.Equipment_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Equipment_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Equipment_Quantity)
                    .IsRequired();

                entity.Property(e => e.Equipment_Available)
                    .IsRequired();

                entity.Property(e => e.Equipment_Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);

                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.Role_ID);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("Training", "dbo");
                entity.HasKey(e => e.Training_ID);

                entity.Property(e => e.Training_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Training_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Training_Certificate)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Training_Link)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Training_Description)
                    .HasMaxLength(250);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.Image_ID);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("Rental", "dbo");
                entity.HasKey(e => e.Rental_ID);

                entity.Property(e => e.Rental_ID)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_ID);

                entity.HasOne(e => e.Equipment)
                    .WithMany()
                    .HasForeignKey(e => e.Equipment_ID);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration", "dbo");
                entity.HasKey(e => e.Registration_ID);

                entity.Property(e => e.Registration_ID)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_ID);

                entity.HasOne(e => e.Opportunity)
                    .WithMany()
                    .HasForeignKey(e => e.Opportunity_ID);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation", "dbo");
                entity.HasKey(e => e.Reservation_ID);

                entity.Property(e => e.Reservation_ID)
                    .ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_ID);

                entity.HasOne(e => e.Room)
                    .WithMany()
                    .HasForeignKey(e => e.Room_ID);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector", "dbo");
                entity.HasKey(e => e.Sector_ID);

                entity.Property(e => e.Sector_ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Sector_Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DatasetType>(entity =>
            {
                entity.ToTable("DatasetType", "dbo");
                entity.HasKey(e => e.DatasetType_ID);

                entity.Property(e => e.DatasetType_ID) 
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.DatasetType_Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Dataset>(entity =>
            {
                entity.ToTable("Dataset", "dbo");
                entity.HasKey(e => e.Dataset_ID);

                entity.Property(e => e.Dataset_ID)
                      .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Sector)
                      .WithMany()
                      .HasForeignKey(e => e.Sector_ID);

                entity.HasOne(e => e.DatasetType)
                      .WithMany()
                      .HasForeignKey(e => e.DatasetType_ID);
            });
        }
    }
}