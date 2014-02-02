using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SystemDot.Core;
using SystemDot.Core.Collections;

namespace SystemDot.Parallelism
{
    public class TaskRepeater : ITaskRepeater
    {
        private class RegisteredAction
        {
            public TimeSpan Delay { get; private set; }

            public Action ToLoop { get; private set; }

            public RegisteredAction(TimeSpan delay, Action toLoop)
            {
                Delay = delay;
                ToLoop = toLoop;
            }
        }

        readonly ITaskScheduler scheduler;
        readonly List<RegisteredAction> registeredActions;
        bool started;

        public TaskRepeater(ITaskScheduler scheduler)
        {
            this.scheduler = scheduler;
            this.registeredActions = new List<RegisteredAction>();
        }

        public void Register(TimeSpan delay, Action toLoop)
        {
            Contract.Requires(delay != null);
            Contract.Requires(toLoop != null);

            if(started)
                ScheduleTask(new RegisteredAction(delay, toLoop));
            else
                registeredActions.Add(new RegisteredAction(delay, toLoop));
        }

        public void Start()
        {
            started = true;
            registeredActions.ForEach(ScheduleTask);
        }

        void ScheduleTask(RegisteredAction task)
        {
            scheduler.ScheduleTask(TimeSpan.FromMilliseconds(1), () => LoopTask(task));
        }

        void LoopTask(RegisteredAction task)
        {
            task.ToLoop();
            scheduler.ScheduleTask(task.Delay, () => LoopTask(task));
        }
    }

}