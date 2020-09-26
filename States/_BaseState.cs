using StateMachineDemo.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace StateMachineDemo.States
{
    public abstract class BaseState : IState
    {
        protected IProcessContext context;

        public BaseState(IProcessContext context)
        {
            this.context = context;
        }

        protected BaseState() {}

        public abstract Type DoAction();

        public virtual bool ShouldExit() => false;

        protected Type ReturnState<T>() where T : IState
        {
            return typeof(T);
        }

        protected void NextHour()
        {
            Console.WriteLine($"Hour: {context.HourOfDay}");
            Thread.Sleep(100);
            context.HourOfDay++;
        }

    }
}
