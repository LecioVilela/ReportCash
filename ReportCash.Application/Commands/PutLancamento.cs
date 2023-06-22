using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Core.Entities;

namespace ReportCash.Application.Commands
{
    public class PutLancamento : IRequest<Guid>
    {
        public PutLancamento(Guid id, decimal valor, string tipo, DateTime data)
        {
            Id = id;
            Valor = valor;
            this.tipo = tipo;
            Data = data;
        }

        public Guid Id { get; private set; }
        public decimal Valor { get; set; }
        public string tipo { get; set; }
        public DateTime Data { get; set; }

    }
}