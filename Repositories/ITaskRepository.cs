using TaskManagerMVC.Models;

namespace TaskManagerMVC.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int taskId);

        IEnumerable<TaskModel> GetAllActive();
        void Add(TaskModel task);
        void Update(int taskId, TaskModel task);
        void Delete(int taskId);
    }
}
