using Adams.RespositoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server
{
    public class AdamsRepositoryServiceServerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }

        public AdamsRepositoryServiceServerDbContext(DbContextOptions<AdamsRepositoryServiceServerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
