using System;
using System.Collections.Generic;
using System.Text;

namespace BoxedIce.ServerDensity.Agent.Tasks
{
    /// <summary>
    /// Management class to perform tasks.
    /// </summary>
    public class TaskRunner
    {
        /// <summary>
        /// Gets or sets the list of tasks.
        /// </summary>
        public IList<ITask> Tasks { get; set; }

        public TaskRunner()
        {
            Tasks = new List<ITask>();
        }

        /// <summary>
        /// Adds a task to the task list.
        /// </summary>
        /// <param name="task">The task to add.</param>
        public void AddTask(ITask task)
        {
            Tasks.Add(task);
        }

        /// <summary>
        /// Performs all tasks.
        /// </summary>
        public void Run()
        {
            foreach (ITask task in Tasks)
            {
                task.Run();
                OnTaskCompleted(new TaskEventArgs(task));
            }
        }

        private void OnTaskCompleted(TaskEventArgs e)
        {
            if (TaskCompleted == null)
                return;
            TaskCompleted(this, e);
        }

        public event TaskEventHandler TaskCompleted;
    }
}
