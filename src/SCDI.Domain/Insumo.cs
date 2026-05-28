using System;

namespace SCDI.Domain
{
    public class Insumo
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Categoria { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        // Construtor usado pelo EF Core e pelas criações
        public Insumo(string nome, string categoria, decimal precoUnitario)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do insumo não pode ser vazio.");
            if (precoUnitario < 0)
                throw new ArgumentException("O preço unitário não pode ser negativo.");

            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;
            PrecoUnitario = precoUnitario;
        }

        // --- MÉTODO COMPATÍVEL COM O SEU NOVO PUT ---
        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco < 0)
                throw new ArgumentException("O preço unitário não pode ser negativo.");
            
            PrecoUnitario = novoPreco;
        }
    }
}
