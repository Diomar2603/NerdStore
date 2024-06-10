using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Profundidade { get; set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeMenorOuIgual(Altura, 0, "Altura não pode ser menor ou igual a zero");
            Validacoes.ValidarSeMenorOuIgual(Largura, 0, "Largura não pode ser menor ou igual a zero");
            Validacoes.ValidarSeMenorOuIgual(Profundidade, 0, "Profundidade não pode ser menor ou igual a zero");
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }

    }
}
