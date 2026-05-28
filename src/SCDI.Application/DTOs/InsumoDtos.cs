namespace SCDI.Application.DTOs
{
    public record CriarInsumoDto(string Nome, int Quantidade, decimal PrecoUnitario, int LimiteMinimoAlerta);
    public record InsumoDto(Guid Id, string Nome, int Quantidade, decimal PrecoUnitario, int LimiteMinimoAlerta, bool AlertaEstoqueBaixo);
}
