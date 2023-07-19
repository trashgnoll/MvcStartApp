using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Controllers.Repositories
{
    public interface IRequestRepository
    {
        public Task AddRequest(string urlInfo);

        Task<Request[]> GetRequests();

    }
}
