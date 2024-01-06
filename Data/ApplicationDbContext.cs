using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DangNgocTuong140.Models;

namespace DangNgocTuong140.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DangNgocTuong140.Models.HocSinh> HocSinh { get; set; } = default!;
    }
}
