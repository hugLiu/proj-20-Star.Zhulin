using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Tasks
{
    public interface ITaskRepository : IRepository<Task>
    {
        string GetTask2(int id);
    }
}
