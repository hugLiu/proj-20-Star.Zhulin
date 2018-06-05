using Abp.EntityFrameworkCore;
using Star.Zhulin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Star.Zhulin.EntityFrameworkCore.Repositories
{
    public class TaskRepository : ZhulinRepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<ZhulinDbContext> dbContextProvider) : base(dbContextProvider)
        { }

        public string GetTask2(int id)
        {
            var query = GetAll();
            query = query.Where(t => t.Id == id);
            var lists = query.ToList();
             
            return lists[0].Title;
        } 
    }
}
