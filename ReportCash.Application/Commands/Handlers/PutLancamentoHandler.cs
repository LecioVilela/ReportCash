using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Core.Enums;
using ReportCash.Core.Repo;

namespace ReportCash.Application.Commands.Handlers
{
    public class PutLancamentoHandler : IRequestHandler<PutLancamento, Guid>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public PutLancamentoHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Guid> Handle(PutLancamento request, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoRepository.GetByIdAsync(request.Id);

            if (Enum.TryParse(request.tipo, out TipoLancamento tipoLancamento))
            {
                lancamento.Update(request.Valor, tipoLancamento, request.Data);
            }
            
            await _lancamentoRepository.UpdateAsync(lancamento);

            return lancamento.Id;
        }
    }
}