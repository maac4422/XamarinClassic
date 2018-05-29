namespace ServiceAccessLayer.Interfaces
{
    using Models.Models;
    using System.Threading.Tasks;

    public interface INewsServices
    {
        Task<Response> GetNews();

        Task<Response> GetNew(int id);
    }
}
