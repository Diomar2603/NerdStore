using AutoMapper;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DtoToDomainMappingProfile: Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProdutoDto, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo, p.Valor, p.DataCadastro, p.Imagem, p.CategoriaId,
                        new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaDto, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
