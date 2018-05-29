namespace ServiceAccessLayer.Services
{
    using System.Threading.Tasks;
    using Models.Models;
    using ServiceAccessLayer.Interfaces;

    public class EventsServices : IEventsServices
    {
        public Task<Response> GetEvent(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> GetEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}
