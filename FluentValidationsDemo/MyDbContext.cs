using Microsoft.EntityFrameworkCore;
using FluentValidationsDemo.Model;

namespace FluentValidationsDemo
{
    public class MyDbContext :DbContext
    {
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Model.FileAttributes> FileAttributes { get; set; }
        public virtual DbSet<ReadGroups> ReadGroups { get; set; }
        public virtual DbSet<ReadUsers> ReadUsers { get; set; }
        public virtual DbSet<Attributes> Attributes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;username=postgres;password=123456;database=NewDemo1");
        }
    }
}
