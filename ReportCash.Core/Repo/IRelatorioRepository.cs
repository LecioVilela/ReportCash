using ReportCash.Core.Entities;

namespace ReportCash.Core.Repo
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> GerarRelatorioDiarioAsync();
    }
}