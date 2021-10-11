using collegemanagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace collegemanagement.DataLayer
{
    public class CollegemanagementDbContext : DbContext
    {
        public CollegemanagementDbContext(DbContextOptions<CollegemanagementDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Seed and create DbSet for all loan class
        /// </summary>
        public DbSet<CollegeActivity> activities { get; set; }
        public DbSet<BranchStudy> branchStudies { get; set; }
        public DbSet<NonTeachingStaff> nonTeachingStaffs { get; set; }
        public DbSet<Professor> professors { get; set; }
        public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CollegeActivity>().HasKey(x => x.Id);
            builder.Entity<BranchStudy>().HasKey(x => x.BranchId);
            builder.Entity<NonTeachingStaff>().HasKey(x => x.Id);
            builder.Entity<Professor>().HasKey(x => x.Id);
            builder.Entity<Student>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
