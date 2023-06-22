using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Entities;

namespace ReportCash.Application.Dtos.ViewModels
{
    public class RelatorioViewModel
    {
        public RelatorioViewModel(decimal saldoDiario, List<Lancamento> lancamentos)
        {
            SaldoDiario = saldoDiario;
            Lancamentos = lancamentos;
        }

        public decimal SaldoDiario { get; private set; }
        public List<Lancamento> Lancamentos { get; private set; }
    }
}