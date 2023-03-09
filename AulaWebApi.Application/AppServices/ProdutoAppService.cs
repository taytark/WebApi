using WebApi.Application.Interfaces;
using WebApi.DTO;
using WebApi.Entities;
using WebApi.Infra.Interfaces;

namespace WebApi.Application.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Delete(int id)
        {
            var produto = GetById(id);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            _produtoRepository.Delete(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            var produtosDTO = produtos.Select(x => new ProdutoDTO
            {
                Id = x.Id,
                Marca = x.Marca,
                Nome = x.Nome,
				Descricao = x.Descricao
            });
            return produtosDTO;
        }

        public Produto GetById(int id)
        {
            return _produtoRepository.GetById(id);
        }

        public ProdutoDTO GetProdutoDTOById(int id) 
        {
            var produto = GetById(id);
            var produtoDTO = new ProdutoDTO();
            produtoDTO.Id = produto.Id;
            produtoDTO.Marca = produto.Marca;
            produtoDTO.Nome = produto.Nome;
            produtoDTO.Descricao = produto.Descricao;
            return produtoDTO;
        }

        public Task<ProdutoDTO> Insert(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Marca = produtoDTO.Marca,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao
            };

            _produtoRepository.Insert(produto);
            return Task.FromResult(produtoDTO);
        }

        public Task<ProdutoDTO> Update(ProdutoDTO produtoDTO)
        {
            var produto = GetById((int)produtoDTO.Id);
            produto.Marca = produtoDTO.Marca;
            produto.Nome = produtoDTO.Nome;
            produto.Descricao = produtoDTO.Descricao;
            _produtoRepository.Update(produto);

            return Task.FromResult(produtoDTO);

        }
    }
}
