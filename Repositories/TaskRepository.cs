﻿using TaskManagerMVC.DataAccess;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Repositories
{
    public class TaskRepository : ITaskRepository

    {
        private readonly TMDBContext _context;
        public TaskRepository(TMDBContext context)
        {
            _context = context;
        }
        public TaskModel Get(int taskId)
       => _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void Update(int taskId, TaskModel task)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
            if (result != null)
            {
                result.Name = task.Name;
                result.Description = task.Description;
                result.Done = task.Done;

                _context.SaveChanges();
            }
        }

        public void Delete(int taskId)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.TaskId ==taskId);
            if (result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }
        }

        public IQueryable<TaskModel> GetAllActive()
        => _context.Tasks.Where(x => !x.Done);

    }
}
