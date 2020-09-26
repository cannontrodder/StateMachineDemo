using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.Models
{

    public class ProcessContext : IProcessContext
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int HourOfDay { get; set; }

        private Type currentState;

        public Type GetCurrentState()
        {
            return currentState;
        }

        public string GetCurrentStateName()
        {
            return currentState.Name;
        }

        public void SetCurrentState<T>()
        {
            currentState = typeof(T);
        }

        public void SetCurrentState(string stateClassName)
        {
            throw new NotImplementedException();
        }
    }
}
