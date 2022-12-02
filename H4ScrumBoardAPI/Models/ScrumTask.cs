using System.Text.Json.Serialization;

namespace H4ScrumBoardAPI.Models
{
    public class ScrumTask
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int StoryPoints { get; set; }
        public string TaskState { get; set; }

        public ScrumTask()
        {

        }
        public ScrumTask(int id,string taskName, string taskDescription, int storyPoints, string taskState)
        {
            ID = id;
            TaskName = taskName;
            TaskDescription = taskDescription;
            StoryPoints = storyPoints;
            TaskState = taskState;
        }
        public ScrumTask(string taskName, string taskDescription, int storyPoints, string taskState)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            StoryPoints = storyPoints;
            TaskState = taskState;
        }
    }
}
