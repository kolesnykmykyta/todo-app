using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoTaskRepository _taskRepository;

        public HomeController(ITodoTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            return View(_taskRepository.GetAll());
        }
    }
}
