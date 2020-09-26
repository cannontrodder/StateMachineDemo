using System;

namespace StateMachineDemo.Interfaces
{
    public interface IProcessContext
    {
        int Age { get; set; }
        int HourOfDay { get; set; }
        string Name { get; set; }

        Type GetCurrentState();
        string GetCurrentStateName();
        void SetCurrentState<T>();
        void SetCurrentState(string stateClassName);
    }
}
