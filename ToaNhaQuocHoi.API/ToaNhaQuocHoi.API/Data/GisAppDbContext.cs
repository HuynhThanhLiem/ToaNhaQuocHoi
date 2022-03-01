using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToaNhaQuocHoi.API.Models;

namespace ToaNhaQuocHoi.API.Data
{
    public class GisAppDbContext : DbContext
    {
        public GisAppDbContext(DbContextOptions<GisAppDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<Face_Block> Face_Blocks { get; set; }
        public DbSet<Face_Node> Face_Nodes { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BlockType> BlockTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>().ToTable("NODE").HasKey(c => c.IDN);
            modelBuilder.Entity<Face>().ToTable("FACE").HasKey(c => c.IDF);
            modelBuilder.Entity<Block>().ToTable("BLOCK").HasKey(c => c.IDB);
            modelBuilder.Entity<Building>().ToTable("BUILDING").HasKey(c => c.IDBD);
            modelBuilder.Entity<BlockType>().ToTable("BLOCKTYPE").HasKey(c => c.IDBT);

            modelBuilder.Entity<Face_Node>().ToTable("FACE_NODE").HasKey(c => new { c.IDF, c.IDN });
            modelBuilder.Entity<Face_Node>().ToTable("FACE_NODE").HasOne<Face>(e => e.Face).WithMany(p => p.Face_Nodes);
            modelBuilder.Entity<Face_Node>().ToTable("FACE_NODE").HasOne<Node>(e => e.Node).WithMany(p => p.Face_Nodes);

            modelBuilder.Entity<Face_Block>().ToTable("FACE_BLOCK").HasKey(c => new { c.IDF, c.IDB });
            modelBuilder.Entity<Face_Block>().ToTable("FACE_BLOCK").HasOne<Face>(e => e.Face).WithMany(p => p.Face_Blocks);
            modelBuilder.Entity<Face_Block>().ToTable("FACE_BLOCK").HasOne<Block>(e => e.Block).WithMany(p => p.Face_Blocks);

        }
    }
}
