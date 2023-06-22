using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ReportCash.Application.Commands;
using ReportCash.Application.Commands.Handlers;
using ReportCash.Core.Entities;
using ReportCash.Core.Enums;
using ReportCash.Infrastructure.Repo;
using Xunit;

namespace ReportCash.Tests.Application.Commands
{
    public class CreateLancamentoCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOK_Executed_ReturnLancamentoId()
        {
            // Arrange
            var lancamentoRepository = new Mock<LancamentoRepository>();

            var createLancamento = new AddLancamento
            {
               
            };

            var createLancamentoHandler = new AddLancamentoHandler(lancamentoRepository.Object);

            // Act
            var id = await createLancamentoHandler.Handle(createLancamento, new CancellationToken());

            // Assert
            Assert.True(id >= Guid.NewGuid());

            lancamentoRepository.Verify(l => l.AddAsync(It.IsAny<Lancamento>()), Times.Once);
        }
    }
}