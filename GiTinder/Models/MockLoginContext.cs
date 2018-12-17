using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class MockLoginContext : DbContext
    {
        public MockLoginContext(DbContextOptions<MockLoginContext> options): base(options)
        {
        }

        public DbSet<MockLoginItem> LoginItems { get; set; }
      

       
    }
}
