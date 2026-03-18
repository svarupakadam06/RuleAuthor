using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Models.Investigator;
using FraudMonitoringSystem.Models.Rules;
using Microsoft.EntityFrameworkCore;


namespace FraudMonitoringSystem.Data
{
    public class WebContext : DbContext 
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<KYCProfile> KYCProfile { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        
       
        public DbSet<Notification> Notifications { get; set; }



        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }
       
        public DbSet<Scenario> Scenarios { get; set; }

        public DbSet<DetectionRule> DetectionRule { get; set; }

        public DbSet<Transaction> Transaction{ get; set; }

        public DbSet<RiskScore> RiskScore { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

           
            modelBuilder.Entity<Notification>()
                .HasKey(n => n.NotificationID);

            modelBuilder.Entity<Notification>()
                .Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Notification>()
                .Property(n => n.Status)
                .HasMaxLength(50);


            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Customer)                 // navigation property in Notification
                .WithMany(c => c.Notifications)          // navigation property in PersonalDetails
                .HasForeignKey(n => n.CustomerId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()

                .HasIndex(r => r.RoleName)

                .IsUnique();


            modelBuilder.Entity<RolePermission>()

                .HasOne(rp => rp.Role)

                .WithMany(r => r.RolePermissions)

                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()

                .HasOne(rp => rp.Permission)

                .WithMany(p => p.RolePermissions)

                .HasForeignKey(rp => rp.PermissionId);


        }
    }
}
