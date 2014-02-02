using System;
using SystemDot.Parallelism;
using Machine.Fakes;
using Machine.Specifications;

namespace SystemDot.Specifications.parallelism
{
    [Subject("parallelism")]
    public class when_starting_task_repeating_with_two_tasks_registered
    {
        static bool repeated1;
        static bool repeated2;
        static TaskRepeater repeater;

        Establish context = () =>
        {
            repeater = new TaskRepeater(new ZeroTimespanPassThroughTaskScheduler());

            repeater.Register(new TimeSpan(0, 0, 1), () => repeated1 = true);
            repeater.Register(new TimeSpan(0, 0, 1), () => repeated2 = true);
        };

        Because of = () => repeater.Start();

        It should_repeat_the_first_task = () => repeated1.ShouldBeTrue();

        It should_repeat_the_second_task = () => repeated2.ShouldBeTrue();        
    }
}