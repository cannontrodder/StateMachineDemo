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
            StateResult result;

            do
            {
                result = currentState.DoAction();

                if (result.ActionRequired == ActionRequiredEnum.TransitionToNewState)
                    currentState = GetNewState(result.GetNextState());

            } while (result.ActionRequired == ActionRequiredEnum.TransitionToNewState);

            if(result.ActionRequired == ActionRequiredEnum.Retry)
            {
                Console.WriteLine($"Looks like we need to retry this later: {currentState.GetType().Name}");
            }

            // otherwise we just do nothing
        }
    }
}
