using MvcStartApp.Models.Db;
using MvcStartApp.Controllers.Repositories;


namespace MvcStartApp.Controllers.Middlewares
{
    public class LoggingMiddleware
    {
        private IWebHostEnvironment env;
        private readonly RequestDelegate _next;
        private IRequestRepository reqRep;

        public LoggingMiddleware(RequestDelegate next, IWebHostEnvironment env, IRequestRepository rep)
        {
            this.env = env;
            _next = next;
            reqRep = rep;
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            await File.AppendAllTextAsync(Path.Combine(env.ContentRootPath, "Logs", "RequestLog.txt"), $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}");
        }

        private async Task LogDb(HttpContext context)
        {
            await reqRep.AddRequest(context.Request.Host.Value + context.Request.Path);
            await File.AppendAllTextAsync(Path.Combine(env.ContentRootPath, "Logs", "RequestLog.txt"), $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogFile(context);
            await LogDb(context);
            await _next.Invoke(context);
        }
    }
}
