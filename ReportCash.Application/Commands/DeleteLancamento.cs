using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ReportCash.Application.Commands
{
    public class DeleteLancamento : IRequest<Guid>
    {
        public DeleteLancamento(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}