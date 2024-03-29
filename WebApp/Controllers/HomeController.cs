﻿using AutoMapper;
using Data.Entities;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View(new TaskModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                await _taskRepository.AddAsync(_mapper.Map<TodoTask>(task));
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            _taskRepository.MarkAsDone(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UncompleteTask(int id)
        {
            _taskRepository.MarkAsNotDone(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(_mapper.Map<TaskModel>(await _taskRepository.GetByIdAsync(id)));
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.Update(_mapper.Map<TodoTask>(task));
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        public IActionResult DeleteAllCompleted()
        {
            _taskRepository.DeleteAllCompleted();
            return RedirectToAction("Index");
        }
    }
}
