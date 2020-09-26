using System;

namespace StateMachineDemo.Interfaces
{
    public interface IProcessContext
    {
        int Age { get; set; }
        int HourOfDay { get; set; }
        string Name { get; set; }
        string CurrentStateName { get; set; }
    }
}
