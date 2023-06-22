using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ReportCash.Application.Queries;
using ReportCash.Application.Queries.Handlers;
using ReportCash.Core.Entities;
using ReportCash.Core.Enums;
using ReportCash.Core.Repo;
using Xunit;

namespace ReportCash.Tests.Queries
{
    public class GetAllLancamentoCommandHandlerTests
    {
        [Fact]
        public async Task ThreeLancamentoExists_Executed_ReturnThreeLancamentoViewModel()
        {
            // Arrange
            var lancamentos = new List<Lancamento>
            {
                new Lancamento(10, DateTime.Now, TipoLancamento.Credito),
                new Lancamento(200, DateTime.Now, TipoLancamento.Debito),
                new Lancamento(300, DateTime.Now, TipoLancamento.Credito)
            };

            var lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            lancamentoRepositoryMock.Setup(l => l.GetAllAsync().Result).Returns(lancamentos);

            var getAllLancamentosQuery = new GetAllLancamento("");
            var getAllLancamentoQueryHandler = new GetAllLancamentoHandler(lancamentoRepositoryMock.Object);

            // Act
            var lancamentoViewModelList = await getAllLancamentoQueryHandler.Handle(getAllLancamentosQuery, new CancellationToken());

            // Assert
            Assert.NotNull(lancamentoViewModelList);
            Assert.NotEmpty(lancamentoViewModelList);
            Assert.Equal(lancamentos.Count, lancamentoViewModelList.Count);

            lancamentoRepositoryMock.Verify(l => l.GetAllAsync().Result, Times.Once);
        }
    }
}