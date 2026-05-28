using System;
using Xunit;
using SCDI.Domain;

namespace SCDI.UnitTests
{
    public class InsumoTests
    {
        [Fact]
        public void CriarInsumo_ComDadosValidos_DeveInstanciarComSucesso()
        {
            // Arrange & Act
            var insumo = new Insumo("Barbecue", "Molhos", 18.00m);

            // Assert
            Assert.NotNull(insumo);
            Assert.Equal("Barbecue", insumo.Nome);
            Assert.Equal(18.00m, insumo.PrecoUnitario);
        }

        [Fact]
        public void CriarInsumo_ComNomeVazio_DeveLancarExcecao()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Insumo("", "Geral", 10.00m));
        }

        [Fact]
        public void CriarInsumo_ComPrecoNegativo_DeveLancarExcecao()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Insumo("Carne", "Geral", -5.00m));
        }

        [Fact]
        public void AtualizarPreco_ComValorValido_DeveAlterarPreco()
        {
            // Arrange
            var insumo = new Insumo("Barbecue", "Molhos", 18.00m);

            // Act
            insumo.AtualizarPreco(22.50m);

            // Assert
            Assert.Equal(22.50m, insumo.PrecoUnitario);
        }
    }
}
