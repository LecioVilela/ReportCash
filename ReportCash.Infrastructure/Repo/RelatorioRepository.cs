using Microsoft.EntityFrameworkCore;
using ReportCash.Core.Entities;
using ReportCash.Core.Enums;
using ReportCash.Core.Repo;
using ReportCash.Infrastructure.Persistence;

namespace ReportCash.Infrastructure.Repo
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ReportCashDbContext _dbContext;

        public RelatorioRepository(ReportCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Relatorio>> GerarRelatorioDiarioAsync()
        {
            var lancamentos = await _dbContext.Lancamentos.ToListAsync();

            decimal saldoDiario = lancamentos.Sum(l => l.Valor);

            var relatorio = new Relatorio(saldoDiario);
            relatorio.Lancamentos = lancamentos;

            var relatorios = new List<Relatorio> { relatorio };

            return relatorios;
        }

    }
}