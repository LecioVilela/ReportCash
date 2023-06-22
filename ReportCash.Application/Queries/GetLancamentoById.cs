using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Application.Dtos.ViewModels;

namespace ReportCash.Application.Queries
{
    public class GetLancamentoById : IRequest<LancamentoViewModel>
    {
        public GetLancamentoById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}