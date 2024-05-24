using Exam9.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam9.DataAccesLayer
{
    public class ServiceContext:IdentityDbContext<AppUser>
    {
        public ServiceContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Service> services { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }
    }
    
}
