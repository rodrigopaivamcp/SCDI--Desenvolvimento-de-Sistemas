using System;

namespace SCDI.Domain.Entities
{
    public class Insumo
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int LimiteMinimoAlerta { get; private set; }

        protected Insumo() { }

        public Insumo(string nome, int quantidade, decimal precoUnitario, int limiteMinimoAlerta)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do insumo não pode ser vazio.");
                
            if (quantidade < 0)
                throw new ArgumentException("A quantidade não pode ser menor que zero.");

            if (precoUnitario < 0)
                throw new ArgumentException("O preço unitário não pode ser menor que zero.");

            if (limiteMinimoAlerta < 0)
                throw new ArgumentException("O limite mínimo de alerta não pode ser menor que zero.");

            Id = Guid.NewGuid();
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            LimiteMinimoAlerta = limiteMinimoAlerta;
        }

        public void AtualizarDados(string nome, int quantity, decimal precoUnitario, int limiteMinimoAlerta)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do insumo não pode ser vazio.");

            if (quantity < 0)
                throw new ArgumentException("A quantidade não pode ser menor que zero.");

            if (precoUnitario < 0)
                throw new ArgumentException("O preço unitário não pode ser menor que zero.");

            if (limiteMinimoAlerta < 0)
                throw new ArgumentException("O limite mínimo de alerta não pode ser menor que zero.");

            Nome = nome;
            Quantidade = quantity;
            PrecoUnitario = precoUnitario;
            LimiteMinimoAlerta = limiteMinimoAlerta;
        }
    }
}