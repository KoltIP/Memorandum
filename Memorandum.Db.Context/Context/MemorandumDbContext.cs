using Memorandum.Db.Context.Setup;
using Memorandum.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.Db.Context.Context
{
    public class MemorandumDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        
        public MemorandumDbContext(DbContextOptions<MemorandumDbContext> option) : base(option)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("notes");
            //modelBuilder.Entity<Note>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Note>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Note>().Property(x => x.Description).HasMaxLength(50);
            modelBuilder.Entity<Note>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Category>().ToTable("categories");
           // modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(x => x.Description).HasMaxLength(50);

            modelBuilder.Entity<Note>().HasOne(x => x.Categoria).WithMany(x => x.Notes).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);

            //DbSeed.AddData(this);
        }

    }
}
