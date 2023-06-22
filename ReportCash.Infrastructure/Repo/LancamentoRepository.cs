using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportCash.Core.Entities;
using ReportCash.Core.Repo;
using ReportCash.Infrastructure.Persistence;

namespace ReportCash.Infrastructure.Repo
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ReportCashDbContext _dbContext;

        public LancamentoRepository(ReportCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            await _dbContext.Lancamentos.AddAsync(lancamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Lancamento>> GetAllAsync()
        {
            var lancamentoGetAll = await _dbContext.Lancamentos.ToListAsync();

            return lancamentoGetAll;
        }

        public async Task<Lancamento> GetByIdAsync(Guid id)
        {
            var lancamentoGet = await _dbContext.Lancamentos.SingleOrDefaultAsync(l => l.Id == id);

            return lancamentoGet;
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            var lancamentoUpdate = await _dbContext.Lancamentos.SingleOrDefaultAsync(l => l.Id == lancamento.Id);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var lancamentoDelete = await _dbContext.Lancamentos.SingleOrDefaultAsync(l => l.Id == id);

            _dbContext.Lancamentos.Remove(lancamentoDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}