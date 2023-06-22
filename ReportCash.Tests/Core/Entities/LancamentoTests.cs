using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Entities;
using ReportCash.Core.Enums;
using Xunit;

namespace ReportCash.Tests.Core.Entities
{
    public class LancamentoTests
    {
        [Fact]
        public void TestIfLancamentoStartWorks()
        {
            var lancamento = new Lancamento(100, DateTime.Now, TipoLancamento.Credito);

            Assert.Equal(TipoLancamento.Credito, lancamento.Tipo);
            Assert.Null(lancamento.Data);

            Assert.NotNull(lancamento.Id);
            Assert.NotEmpty(lancamento.Id.ToString());

            Assert.NotNull(lancamento.Valor);
            Assert.NotEmpty(lancamento.Valor.ToString());

            lancamento.LancamentoCredito();

            Assert.Equal(TipoLancamento.Credito, lancamento.Tipo);
            Assert.NotNull(lancamento.Data);
        }
    }
}