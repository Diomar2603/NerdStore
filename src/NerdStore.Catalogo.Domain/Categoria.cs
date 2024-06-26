﻿using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {
            
        }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O nome não pode ser vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O Código não pode ser zero");
        }
    }
}
