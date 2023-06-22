using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Core.Enums;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Commands.Handlers
{
    public class AddLancamentoHandler : IRequestHandler<AddLancamento, Guid>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public AddLancamentoHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Guid> Handle(AddLancamento request, CancellationToken cancellationToken)
        {
            var lancamento = request.ToEntity();

            if (Enum.TryParse(request.Lancamento.tipo.ToString(), out TipoLancamento tipoLancamento))
            {
                await _lancamentoRepository.AddAsync(lancamento);
            }
            
            return lancamento.Id;
        }
    }
}