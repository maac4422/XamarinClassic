namespace BusinessLayer.Interfaces
{
    using Models.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsBusinessLogic
    {
        Task<List<News>> GetNews();

        Task<News> GetNew(int id);
    }
}
