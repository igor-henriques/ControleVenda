using Infra.Models.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos();
        Task<Produto> Get(int Id);
        Task<Produto> Get(string nome);
        Task Add(Produto produto);
        Task Remove(int Id);
        Task Remove(List<Produto> produtos);
        Task Update(Produto produto);
        Task Save();
        Task<IEnumerable<Produto>> Pesquisar(string campo, string conteudo);
    }
}
