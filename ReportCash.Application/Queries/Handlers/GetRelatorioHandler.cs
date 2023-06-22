using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Application.Dtos.ViewModels;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Queries.Handlers
{
    public class GetRelatorioHandler : IRequestHandler<GetRelatorio, List<RelatorioViewModel>>
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public GetRelatorioHandler(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<List<RelatorioViewModel>> Handle(GetRelatorio request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioRepository.GerarRelatorioDiarioAsync();

            var relatorioViewModel = relatorio
                .Select(r => new RelatorioViewModel(r.SaldoDiario, r.Lancamentos))
                .ToList();

            return relatorioViewModel;
        }
    }
}