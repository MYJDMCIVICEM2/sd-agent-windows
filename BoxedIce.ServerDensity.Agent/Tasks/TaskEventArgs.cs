using System;
using System.Collections.Generic;
using System.Text;

namespace BoxedIce.ServerDensity.Agent.Tasks
{
    public delegate void TaskEventHandler(object sender, TaskEventArgs e);

    public class TaskEventArgs : EventArgs
    {
        public ITask Task { get; set; }

        public TaskEventArgs(ITask task)
        {
            Task = task;
        }
    }
}
