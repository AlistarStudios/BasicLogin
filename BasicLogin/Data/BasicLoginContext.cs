using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicLogin.Models;

namespace BasicLogin.Data
{
    public class BasicLoginContext : DbContext
    {
        public BasicLoginContext (DbContextOptions<BasicLoginContext> options)
            : base(options)
        {
        }

        public DbSet<BasicLogin.Models.UserAccount> UserAccount { get; set; } = default!;
    }
}
