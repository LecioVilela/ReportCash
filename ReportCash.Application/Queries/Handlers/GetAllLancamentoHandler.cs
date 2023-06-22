using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Application.Dtos.ViewModels;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Queries.Handlers
{
    public class GetAllLancamentoHandler : IRequestHandler<GetAllLancamento, List<LancamentoViewModel>>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public GetAllLancamentoHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<List<LancamentoViewModel>> Handle(GetAllLancamento request, CancellationToken cancellationToken)
        {
            var lancamentos = await _lancamentoRepository.GetAllAsync();

            var lancamentosViewModel = lancamentos
            .Select(l => new LancamentoViewModel(l.Id, l.Valor, l.Tipo.ToString(), l.Data))
            .ToList();

            return lancamentosViewModel;
        }
    }
}