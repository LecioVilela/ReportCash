using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportCash.Core.Entities;

namespace ReportCash.Infrastructure.Persistence
{
    public class ReportCashDbContext : DbContext
    {
        public ReportCashDbContext(DbContextOptions<ReportCashDbContext> options) : base(options)
        {

        }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Valor).IsRequired();
                entity.Property(l => l.Tipo).IsRequired();
                entity.Property(l => l.Data).IsRequired();
            });

            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasNoKey();
                entity.Property(r => r.SaldoDiario).IsRequired();
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}