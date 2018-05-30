namespace ServiceAccessLayer.Services
{
    using System.Threading.Tasks;
    using Models.Models;
    using ServiceAccessLayer.Constants;
    using ServiceAccessLayer.Interfaces;

    public class EventsServices : IEventsServices
    {
        #region Attributes
        private ApiServices apiServices;
        #endregion

        #region Constructors
        public EventsServices()
        {
            this.apiServices = new ApiServices();
        }
        #endregion

        #region Methods
        public async Task<Response> GetEvent(int id)
        {
            var response = await apiServices.Get<Events>(
                ServicesConstants.UrlBase,
                ServicesConstants.ServisePrefix,
                EndPointsConstants.Events, id);
            return response;
        }

        public async Task<Response> GetEvents()
        {
            var response = await apiServices.GetList<Events>(
               ServicesConstants.UrlBase,
               ServicesConstants.ServisePrefix,
               EndPointsConstants.Events);
            return response;
        }
        #endregion
    }
}
