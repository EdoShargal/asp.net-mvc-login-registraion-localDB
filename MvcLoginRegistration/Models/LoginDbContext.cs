 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcLoginRegistration.Models
{
    public class LoginDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}