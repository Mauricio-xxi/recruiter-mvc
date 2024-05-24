using Microsoft.EntityFrameworkCore;
using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Infrastructure.Contexts
{
    public class RecruiterAppContext : DbContext
    {
        public RecruiterAppContext(DbContextOptions<RecruiterAppContext> options)
            : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.IdCandidate);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Birthdate).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(250);
                entity.Property(e => e.InsertDate).IsRequired();
                entity.Property(e => e.ModifyDate);

                entity.HasMany(e => e.CandidateExperiences)
                      .WithOne(e => e.Candidate)
                      .HasForeignKey(e => e.IdCandidate);
            });

            modelBuilder.Entity<CandidateExperience>(entity =>
            {
                entity.HasKey(e => e.IdCandidateExperience);
                entity.Property(e => e.Company).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Job).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.Salary).HasColumnType("decimal(8,2)");
                entity.Property(e => e.BeginDate).IsRequired();
                entity.Property(e => e.EndDate);
                entity.Property(e => e.InsertDate).IsRequired();
                entity.Property(e => e.ModifyDate);
            });
        }
    }
}
