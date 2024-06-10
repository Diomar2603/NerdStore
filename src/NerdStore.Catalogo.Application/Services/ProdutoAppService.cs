using AutoMapper;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IEstoqueService estoqueService)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _estoqueService = estoqueService;
        }

        public async Task AdicionarProduto(ProdutoDto ProdutoDto)
        {
            _produtoRepository.Adicionar(_mapper.Map<Produto>(ProdutoDto));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDto ProdutoDto)
        {
            _produtoRepository.Atualizar(_mapper.Map<Produto>(ProdutoDto));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<CategoriaDto>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDto>>(await _produtoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigoCategoria)
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterPorCategoria(codigoCategoria));
        }

        public async Task<ProdutoDto> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodos()
        {
            var olha = _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterTodos());
            return olha;
        }

        public async Task<ProdutoDto> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao repor estoque");

            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }


        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}
