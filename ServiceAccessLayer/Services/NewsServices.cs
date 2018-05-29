
namespace ServiceAccessLayer.Services
{
    using System.Threading.Tasks;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;

    public class NewsServices : INewsServices
    {
        public Task<Response> GetNew(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> GetNews()
        {
            throw new System.NotImplementedException();
        }
    }
}
