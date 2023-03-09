using WebApi.DTO;
using WebApi.Entities;

namespace WebApi.Application.Interfaces
{
	public interface IProdutoAppService
    {
        IEnumerable<ProdutoDTO> GetAll();

        Produto GetById(int id);

        ProdutoDTO GetProdutoDTOById(int id);

        Task<ProdutoDTO> Insert(ProdutoDTO produtoDTO);

        Task<ProdutoDTO> Update(ProdutoDTO produtoDTO);

        void Delete(int id);
    }
}
