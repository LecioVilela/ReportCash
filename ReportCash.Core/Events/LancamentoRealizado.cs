using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Enums;

namespace ReportCash.Core.Events
{
    public class LancamentoRealizado : IDomainEvent
    {
        public LancamentoRealizado(Guid id, decimal valor, TipoLancamento tipo)
        {
            Id = id;
            Valor = valor;
            Tipo = tipo;
        }

        public Guid Id { get; }
        public decimal Valor { get; }
        public TipoLancamento Tipo { get; set; }
    }
}