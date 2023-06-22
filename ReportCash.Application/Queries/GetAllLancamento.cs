using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReportCash.Application.Dtos.ViewModels;

namespace ReportCash.Application.Queries
{
    public class GetAllLancamento : IRequest<List<LancamentoViewModel>>
    {
        public GetAllLancamento(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}