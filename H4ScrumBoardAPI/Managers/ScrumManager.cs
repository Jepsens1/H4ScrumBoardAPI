using H4ScrumBoardAPI.Database;
using H4ScrumBoardAPI.Models;

namespace H4ScrumBoardAPI.Managers
{
    public class ScrumManager
    {
        DataAccess database = new DataAccess();

        public List<ScrumTask> GetScrumTasks()
        {
            return database.GetScrumTasks();
        }
        public ScrumTask GetScrumTaskByID(int id)
        {
            return database.GetScrumTaskByID(id);
        }
        public ScrumTask CreateNewScrumTask(ScrumTask task)
        {
            return database.CreateNewTask(task);
        }
        public ScrumTask UpdateScrumTask(ScrumTask task)
        {
            return database.UpdateScrumTask(task);
        }
        public string DeleteScrumTask(int id)
        {
            return database.DeleteScrumTask(id);
        }

    }
}
