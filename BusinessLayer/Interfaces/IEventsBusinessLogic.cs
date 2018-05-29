namespace BusinessLayer.Interfaces
{
    using Models.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEventsBusinessLogic
    {
        Task<List<Events>> GetEvents();

        Task<Events> GetEvent(int id);
    }
}
