
namespace ServiceAccessLayer.Services
{
    using System.Threading.Tasks;
    using Models.Models;
    using ServiceAccessLayer.Constants;
    using ServiceAccessLayer.Interfaces;

    public class NewsServices : INewsServices
    {
        #region Attributes
        private ApiServices apiServices;
        #endregion

        #region Constructors
        public NewsServices()
        {
            this.apiServices = new ApiServices();
        }
        #endregion

        public async Task<Response> GetNew(int id)
        {
            var response = await apiServices.Get<News>(
                ServicesConstants.UrlBase,
                ServicesConstants.ServisePrefix,
                EndPointsConstants.News, id);
            return response;
        }

        public async Task<Response> GetNews()
        {
            var response = await apiServices.GetList<News>(
               ServicesConstants.UrlBase,
               ServicesConstants.ServisePrefix,
               EndPointsConstants.News);
            return response;
        }
    }
}
