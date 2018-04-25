using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CryptoSanctuary.Models
{
    public class CryptidDBContext : DbContext
    {
        public CryptidDBContext()
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=cryptid;uid=root;pwd=root;");
        }
        public CryptidDBContext(DbContextOptions<CryptidDBContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
