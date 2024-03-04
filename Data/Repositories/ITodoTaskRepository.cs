using Data.Entities;
using Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal interface ITodoTaskRepository : IRepository<TodoTask>
    {
        public void MarkAsDone(int id);

        public void MarkAsNotDone(int id);
    }
}
