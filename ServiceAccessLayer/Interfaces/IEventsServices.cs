namespace ServiceAccessLayer.Interfaces
{
    using Models.Models;
    using System.Threading.Tasks;

    public interface IEventsServices
    {
        Task<Response> GetEvents();

        Task<Response> GetEvent(int id);
    }
}
