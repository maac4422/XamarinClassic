namespace BusinessLayer.BusinessLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Models.Models;

    public class NewsBusinessLogic : INewsBusinessLogic
    {
        public Task<News> GetNew(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<News>> GetNews()
        {
            throw new System.NotImplementedException();
        }
    }
}
