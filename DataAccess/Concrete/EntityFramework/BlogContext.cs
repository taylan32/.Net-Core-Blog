using Core.Entities.Concrete;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;database=Blog;Trusted_Connection=true");
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet<OperationClaim> operationClaims { get; set; }
        public DbSet<UserOperationClaim> userOperationClaims { get; set; }
    }
}
