using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovaMentoria.Models;
using NovaMentoriaSistema.Models;

namespace NovaMentoria.Data
{
      public class ApplicationDbContext : IdentityDbContext<Person, IdentityRole<int>,int>
    //public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<PersonLearning> PersonLearnings { get; set; }
        public DbSet<PersonFeedback> PersonFeedbacks { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Circle> Circle { get; set; }
        public DbSet<TypeConsultor> TypeConsultor { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ActualState> ActualStates { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<NovaMentoria.Models.PeopleLearn> PeopleLearn { get; set; }
        public DbSet<NovaMentoria.Models.Project> Projects { get; set; }
        public DbSet<NovaMentoria.Models.ActualState> PlanoResumo { get; set; }
        public DbSet<NovaMentoria.Models.Circle> Circles { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<NovaMentoria.Models.HourDay> HourDay { get; set; }
        public DbSet<NovaMentoria.Models.BankAccount> BankAccount { get; set; }
        public DbSet<NovaMentoria.Models.Capture> Capture { get; set; }
        public DbSet<NovaMentoria.Models.CostCenter> CostCenter { get; set; }
        public DbSet<NovaMentoria.Models.Enterprise> Enterprise { get; set; }
        public DbSet<NovaMentoria.Models.Expensive> Expensive { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActualState>()
                  .HasOne(e => e.Person)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonFeedback>()
                 .HasOne(e => e.Person)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonLearning>()
                  .HasOne(e => e.Person)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}