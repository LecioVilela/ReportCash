using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Entities;

namespace ReportCash.Core.Repo
{
    public interface ILancamentoRepository
    {
        Task<List<Lancamento>> GetAllAsync();
        Task<Lancamento> GetByIdAsync(Guid id);
        Task AddAsync(Lancamento lancamento);
        Task UpdateAsync(Lancamento lancamento);
        Task DeleteAsync(Guid id);
    }
}