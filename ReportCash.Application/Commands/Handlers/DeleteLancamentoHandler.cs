using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Commands.Handlers
{
    public class DeleteLancamentoHandler : IRequestHandler<DeleteLancamento, Guid>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public DeleteLancamentoHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Guid> Handle(DeleteLancamento request, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoRepository.GetByIdAsync(request.Id);

            if (lancamento is null)
            {
                throw new Exception("Ooops! Lancamento não encontado...");
            }

            await _lancamentoRepository.DeleteAsync(request.Id);

            return lancamento.Id;
        }
    }
}