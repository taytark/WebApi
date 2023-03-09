using Microsoft.AspNetCore.Http;

namespace WebApi.DTO
{
    public class ProdutoDTO
    {
        public int? Id { get; set; } = null;

        public string Nome { get; set; }

        public string Marca { get; set; }
        public string Descricao { get; set; }
    }
}
