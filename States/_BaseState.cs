using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace StateMachineDemo.States
{
    public abstract class BaseState<T> : IState
    {
        protected IProcessContext context;

        public BaseState(IProcessContext context, ILogger logger)
        {
            this.context = context;
            context.CurrentStateName = typeof(T).FullName;

            logger.Log($"In state {context.CurrentStateName}");
        }

        protected BaseState() {}

        public abstract StateResult DoAction();

        protected StateResult ReturnState<R>() where R : IState
        {
            return StateResult.MoveToThisState<R>();
        }

        protected void NextHour()
        {
            Console.WriteLine($"Hour: {context.HourOfDay}");
            Thread.Sleep(100);
            context.HourOfDay++;
        }

    }
}
