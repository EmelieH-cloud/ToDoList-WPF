namespace ToDoList_WPF
{
    internal class Task
    {
        public Priority Priority { get; set; }
        public TaskType TaskType { get; set; }

        public string GetTaskInfo()
        {
            return $"Task: {TaskType}, Priority: {Priority}";
        }



    }
}
