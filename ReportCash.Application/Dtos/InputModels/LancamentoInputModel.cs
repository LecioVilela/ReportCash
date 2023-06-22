using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportCash.Application.Dtos.InputModels
{
    public class LancamentoInputModel
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string tipo { get; set; }
        public DateTime Data { get; set; }
    }
}