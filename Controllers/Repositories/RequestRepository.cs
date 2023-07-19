using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Controllers.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }

        public async Task AddRequest(string urlInfo)
        {
            Request request = new();
            request.Url = urlInfo;

            // Добавление пользователя
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
    }
}
