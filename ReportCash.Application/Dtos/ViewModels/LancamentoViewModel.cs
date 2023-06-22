using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Entities;

namespace ReportCash.Application.Dtos.ViewModels
{
    public class LancamentoViewModel
    {
        public LancamentoViewModel(Guid id, decimal valor, string tipo, DateTime data)
        {
            Id = id;
            Valor = valor;
            this.tipo = tipo;
            Data = data;
        }

        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public string tipo { get; private set; }
        public DateTime Data { get; private set; }

        public static LancamentoViewModel FromEntity(Lancamento lancamento)
        {
            return new LancamentoViewModel(
                lancamento.Id,
                lancamento.Valor,
                lancamento.Tipo.ToString(),
                lancamento.Data
            );
        }
    }
        
    
}