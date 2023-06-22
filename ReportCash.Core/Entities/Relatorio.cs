using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportCash.Core.Entities
{
    public class Relatorio
    {
        public Relatorio(decimal saldoDiario)
        {
            SaldoDiario = saldoDiario;
        }

        public decimal SaldoDiario { get; private set; }
        public List<Lancamento> Lancamentos { get;  set; }
    }

}