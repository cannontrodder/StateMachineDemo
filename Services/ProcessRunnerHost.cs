using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.States;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace StateMachineDemo.Services
{
    public class ProcessRunnerHost : IProcessRunnerHost
    {
        private readonly IServiceProvider serviceProvider;
        private IState currentState;
        private IProcessContext context;

        public ProcessRunnerHost(IServiceProvider serviceProvider, IProcessContext context)
        {
            this.serviceProvider = serviceProvider;
            this.context = context;

            currentState = GetNewState<Start>();
        }

        private T GetNewState<T>()
        {
            return ActivatorUtilities.CreateInstance<T>(serviceProvider, context);
        }

        private IState GetNewState(Type instanceType)
        {
            return (IState)ActivatorUtilities.CreateInstance(serviceProvider, instanceType, context);
        }

        public void Start()
        {
            while (!currentState.ShouldExit())
            {
                var nextType = currentState.DoAction();
                currentState = GetNewState(nextType);
            }
        }
    }
}
