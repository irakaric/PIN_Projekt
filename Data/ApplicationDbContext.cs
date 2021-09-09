using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PIN_Projekt.Models;

namespace PIN_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PIN_Projekt.Models.Studenti> Studenti { get; set; }
        public DbSet<PIN_Projekt.Models.Predmeti> Predmeti { get; set; }
    }
}
