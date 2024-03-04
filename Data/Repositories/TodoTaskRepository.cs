using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoDbContext _context;

        public TodoTaskRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoTask entity)
        {
            await _context.Tasks.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TodoTask? taskToRemove = _context.Tasks.Find(id);
            if (taskToRemove != null)
            {
                _context.Tasks.Remove(taskToRemove);
            }

            _context.SaveChanges();
        }

        public IEnumerable<TodoTask> GetAll()
        {
            IEnumerable<TodoTask> output = _context.Tasks;
            return output;
        }

        public async Task<TodoTask?> GetByIdAsync(int id)
        {
            TodoTask? output = await _context.Tasks.FindAsync(id);
            return output;
        }

        public void MarkAsDone(int id)
        {
            this.ChangeTaskStatus(id, true);
        }

        public void MarkAsNotDone(int id)
        {
            this.ChangeTaskStatus(id, false);
        }

        public void Update(TodoTask entity)
        {
            _context.Tasks.Update(entity);
            _context.SaveChanges();
        }

        private void ChangeTaskStatus(int id, bool status)
        {
            TodoTask? taskToChange = _context.Tasks.Find(id);
            if (taskToChange != null)
            {
                taskToChange.IsDone = status;
            }

            _context.SaveChanges();
        }
    }
}
