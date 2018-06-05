using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star.Zhulin.Tasks
{
    public class TaskService : IApplicationService, ITaskService
    {
        public readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public string GetTask(int id)
        {
            return _taskRepository.GetTask2(id);
        }
    }
}
