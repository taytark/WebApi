using WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Infra.Interfaces
{
    public interface IProdutoRepository 
    {
        IEnumerable<Produto> GetAll();

        Produto GetById(int id);

        void Insert(Produto produtoDTO);

        void Update(Produto produtoDTO);

        void Delete(Produto produto);
    }
}
