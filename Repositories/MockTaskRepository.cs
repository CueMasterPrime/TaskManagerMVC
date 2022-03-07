using System.Linq;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Repositories
{
    public class MockTaskRepository : ITaskRepository
    {
        private List<TaskModel> _tasksList;

        public MockTaskRepository()
        {
            _tasksList = new List<TaskModel>()
            {
                new TaskModel() { TaskId = 1, Name = "Zakupy", Description = "Zrob zakupy w piatek", Done = false },
                new TaskModel() { TaskId = 2, Name = "Obiad", Description = "Zrob obiad w piatek", Done = true},
                new TaskModel() { TaskId = 3, Name = "Kosciolek", Description = "Zrob kosciolek w piatek", Done = false }

            };
        }

        public void Add(TaskModel task)
        {
            task.TaskId = _tasksList.Max(e => e.TaskId) + 1;
            _tasksList.Add(task);
        }

        public void Delete(int taskId)
        {
            var result = _tasksList.FirstOrDefault(e => e.TaskId == taskId);
            if (result != null)
            {
                _tasksList.Remove(result);  
            }
        }

        public TaskModel Get(int taskId)
      => _tasksList.FirstOrDefault(e => e.TaskId == taskId);

        public IEnumerable<TaskModel> GetAllActive()
        {

            var result = _tasksList.Where(x => !x.Done);
            return result;  


        }
       

        public void Update(int taskId, TaskModel task)
        {
            var result = _tasksList.FirstOrDefault(e => e.TaskId == taskId);
            if (result != null)
            {
                result.Name = task.Name;
                result.Description = task.Description;
                result.Done = task.Done;
            }
        }
    }
}
