
using ApiTreino.Data.Maps;
using ApiTreino.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTreino.Data.Context
  
{
    public class MembroContext : DbContext
    {
        public MembroContext(DbContextOptions<MembroContext> options )  : base(options){ }

        public DbSet<MembroModel> membro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MembroMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
