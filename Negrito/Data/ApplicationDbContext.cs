using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Negrito.Models;

namespace Negrito.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Contato> Contato { get; set; }
    }
}
