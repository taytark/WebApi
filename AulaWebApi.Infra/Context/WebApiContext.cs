using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiMentoria
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
