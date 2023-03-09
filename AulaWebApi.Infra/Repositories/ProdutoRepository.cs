using WebApi.Entities;
using WebApi.Infra.Interfaces;
using WebApiMentoria;

namespace WebApi.Infra.Repositories
{
	public class ProdutoRepository : IProdutoRepository
    {
        private readonly WebApiContext _webApiContext;

        public ProdutoRepository(WebApiContext webApiContext)
        {
            _webApiContext = webApiContext;
        }

        public void Delete(Produto produto)
        {
            _webApiContext.Produtos.Remove(produto);
            _webApiContext.SaveChanges();
        }

        public IEnumerable<Produto> GetAll()
        {
            return _webApiContext.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _webApiContext.Produtos.Find(id);
        }

        public void Insert(Produto produto)
        {
            _webApiContext.Produtos.Add(produto);
            _webApiContext.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _webApiContext.Produtos.Update(produto);
            _webApiContext.SaveChanges();
        }
    }
}
