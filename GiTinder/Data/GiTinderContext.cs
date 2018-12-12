using GiTinder.Models;
using Microsoft.EntityFrameworkCore;

namespace GiTinder.Data
{
    public class GiTinderContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
    }
}
