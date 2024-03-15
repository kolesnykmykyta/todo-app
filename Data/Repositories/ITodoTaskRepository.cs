using Data.Entities;
using Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        void MarkAsDone(int id);

        void MarkAsNotDone(int id);

        void DeleteAllCompleted();
    }
}
