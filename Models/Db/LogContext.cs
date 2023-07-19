using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class LogContext : DbContext
    {
        /// Ссылка на таблицу Request
        public DbSet<Request> Requests{ get; set; }

        // Логика взаимодействия с таблицами в БД
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}