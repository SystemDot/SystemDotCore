using System;
using SystemDot.Parallelism;
using Machine.Specifications;

namespace SystemDot.Specifications.parallelism
{
    [Subject("parallelism")]
    public class when_starting_task_repeating_with_a_task_registered_and_the_time_delay_has_passed_twice
    {
        static int taskHappened;
        static TestSystemTime systemTime;
        static TaskRepeater repeater;

        Establish context = () =>
        {
            systemTime = new TestSystemTime(DateTime.Now);
            
            repeater = new TaskRepeater(new TestTaskScheduler(systemTime)
            {
                SchedulesPermitted = 2
            });

            repeater.Register(TimeSpan.FromSeconds(1), () => taskHappened++);
        };

        Because of = () =>
        {
            repeater.Start();
            systemTime.AdvanceTime(TimeSpan.FromSeconds(1));
            systemTime.AdvanceTime(TimeSpan.FromSeconds(1));
        };

        It should_repeat_the_task_twice = () => taskHappened.ShouldEqual(2);
    }
}