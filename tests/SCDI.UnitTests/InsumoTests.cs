using System;
using SCDI.Domain.Entities;
using Xunit;

namespace SCDI.UnitTests.Domain
{
    public class InsumoTests
    {
        [Fact]
        public void CriarInsumo_ComDadosValidos_DeveInstanciarComSucesso()
        {
            var insumo = new Insumo("Maionese", 10, 25.00m, 5);
            Assert.NotEqual(Guid.Empty, insumo.Id);
            Assert.Equal("Maionese", insumo.Nome);
            Assert.Equal(10, insumo.Quantidade);
        }

        [Fact]
        public void CriarInsumo_ComNomeVazio_DeveLancarArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Insumo("", 10, 25.00m, 5));
        }

        [Fact]
        public void CriarInsumo_ComPrecoNegativo_DeveLancarArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Insumo("Maionese", 10, -5.00m, 5));
        }

        [Fact]
        public void AtualizarDados_ComValorValido_DeveAlterarDados()
        {
            var insumo = new Insumo("Maionese", 10, 25.00m, 5);
            insumo.AtualizarDados("Maionese Gourmet", 15, 28.50m, 8);
            Assert.Equal(28.50m, insumo.PrecoUnitario);
            Assert.Equal(15, insumo.Quantidade);
        }
    }
}