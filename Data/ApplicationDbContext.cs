namespace GiftOfTheGivers.Data
{
    using GiftOfTheGivers.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Donation> Donations => Set<Donation>();
        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<VolunteerProject> VolunteerProjects => Set<VolunteerProject>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<IncidentReport> IncidentReports => Set<IncidentReport>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VolunteerProject>().HasKey(vp => new { vp.VolunteerId, vp.ProjectId });

            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Volunteer>().HasIndex(v => v.Email).IsUnique();
            modelBuilder.Entity<Donation>()
        .Property(d => d.Amount)
        .HasPrecision(18, 2); 
            modelBuilder.Entity<Project>().Property(p => p.Status).HasDefaultValue("planned");
            modelBuilder.Entity<IncidentReport>().Property(i => i.Status).HasDefaultValue("open");
            modelBuilder.Entity<IncidentReport>().Property(i => i.Severity).HasDefaultValue("medium");
        }
    }

}
