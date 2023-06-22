using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Enums;
using ReportCash.Core.Events;

namespace ReportCash.Core.Entities
{
    public class Lancamento : AggregateRoot
    {
        public Lancamento(decimal valor, DateTime data, TipoLancamento tipo)
        {
            Id = Guid.NewGuid();
            Valor = valor;           
            Tipo = tipo;
            Data = DateTime.Now;

            AddEvent(new LancamentoRealizado(Id, Valor, Tipo));
        }

        public decimal Valor { get; private set; }
        public TipoLancamento Tipo { get; private set; }
        public DateTime Data { get; private set; }

        public void LancamentoDebito()
        {
            Tipo = TipoLancamento.Debito;
        }

        public void LancamentoCredito()
        {
            Tipo = TipoLancamento.Credito;
        }

        public void Update(decimal valor, TipoLancamento tipo, DateTime data)
        {
            Valor = valor;
            Tipo = tipo;
            Data = data;
        }
    }
}