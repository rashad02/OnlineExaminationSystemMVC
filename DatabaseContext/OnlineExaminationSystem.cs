using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DatabaseContext
{
    public class OnlineExaminationSystem :DbContext
    {
        public DbSet<AdminCredentials> AdminCredentialses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Exams> Examses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Tags> Tagses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Result> Results { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOptional(r=>r.Results)
            .WithMany().WillCascadeOnDelete(false);
            
    }


    }
}
