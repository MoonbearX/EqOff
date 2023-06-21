using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EqOff.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Reflection.Metadata;

namespace EqOff.Data
{
    public class ApplContext : IdentityDbContext
    {
        public ApplContext(DbContextOptions<ApplContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WriteOff> WriteOffs { get; set; }
    }
}
