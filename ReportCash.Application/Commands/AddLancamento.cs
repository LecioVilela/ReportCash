using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Core.Entities;
using ReportCash.Core.Enums;

namespace ReportCash.Application.Commands
{
    public class AddLancamento : IRequest<Guid>
    {
        public LancamentoInputModel Lancamento { get; set; }

        public Lancamento ToEntity()
        {
            return new Lancamento(
                Lancamento.Valor, Lancamento.Data, Lancamento.tipo
            );
        }
    }

    public class LancamentoInputModel
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento tipo { get; set; }
        public DateTime Data { get; set; }
    }
}