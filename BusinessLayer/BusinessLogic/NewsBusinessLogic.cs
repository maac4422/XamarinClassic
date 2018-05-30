namespace BusinessLayer.BusinessLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;

    public class NewsBusinessLogic : INewsBusinessLogic
    {
        #region Attributes
        private INewsServices newsServices;
        #endregion

        #region Constructors
        public NewsBusinessLogic()
        {
            newsServices = new NewsServices();
        }
        #endregion

        public Task<News> GetNew(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<News>> GetNews()
        {
            var response = await newsServices.GetNews();
            if (!response.IsSuccess)
            {
            }
            var news = (List<News>)response.Result;

            return news;
        }
    }
}
