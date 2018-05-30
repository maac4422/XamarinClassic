namespace BusinessLayer.BusinessLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;

    public class EventsBusinessLogic : IEventsBusinessLogic
    {
        #region Attributes
        private IEventsServices eventsServices;
        #endregion

        #region Constructors
        public EventsBusinessLogic()
        {
            eventsServices = new EventsServices();
        }
        #endregion

        #region Methods
        public Task<Events> GetEvent(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Events>> GetEvents()
        {
            var response = await eventsServices.GetEvents();
            if (!response.IsSuccess)
            {
            }
            var events = (List<Events>)response.Result;

            return events;
        }
        #endregion
    }
}
