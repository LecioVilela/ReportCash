using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Application.Dtos.ViewModels;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Queries.Handlers
{
    public class GetLancamentoByIdHandler : IRequestHandler<GetLancamentoById, LancamentoViewModel>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public GetLancamentoByIdHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<LancamentoViewModel> Handle(GetLancamentoById request, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoRepository.GetByIdAsync(request.Id);

            var lancamentoViewModel = LancamentoViewModel.FromEntity(lancamento);

            return lancamentoViewModel;
        }
    }
}