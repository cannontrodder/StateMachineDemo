using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
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

        public abstract StateResult DoAction();

        protected StateResult ReturnState<T>() where T : IState
        {
            return StateResult.MoveToThisState<T>();
        }

        protected void NextHour()
        {
            Console.WriteLine($"Hour: {context.HourOfDay}");
            Thread.Sleep(100);
            context.HourOfDay++;
        }

    }
}
