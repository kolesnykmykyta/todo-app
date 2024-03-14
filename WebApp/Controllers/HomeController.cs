using AutoMapper;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoTaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public HomeController(ITodoTaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<TaskModel>>(_taskRepository.GetAll()));
        }
    }
}
