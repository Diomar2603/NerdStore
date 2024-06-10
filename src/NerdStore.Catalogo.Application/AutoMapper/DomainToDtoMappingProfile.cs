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
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(pvm => pvm.Largura, o => o.MapFrom(p => p.Dimensoes.Largura))
                .ForMember(pvm => pvm.Altura, o => o.MapFrom(p => p.Dimensoes.Altura))
                .ForMember(pvm => pvm.Profundidade, o => o.MapFrom(p => p.Dimensoes.Profundidade));
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
