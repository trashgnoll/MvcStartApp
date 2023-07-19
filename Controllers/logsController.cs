using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Controllers.Repositories;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System.Diagnostics;

namespace MvcStartApp.Controllers
{
    public class logsController: Controller
    {
        private readonly IRequestRepository _repo;

        public logsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();
            return View(requests);
        }
    }
}
