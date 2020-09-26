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
        private IProcessContext context;

        public ProcessRunnerHost(IServiceProvider serviceProvider, IProcessContext context)
        {
            this.serviceProvider = serviceProvider;
            this.context = context;
        }

        // do I need this now?
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
            // we should be able to do MoveToThisState with a type hydrated at run time from the context
            // the context will have it as a string so we will need to validate it is the right type
            // rest of the time, use the generic for type safety

            var result = StateResult.MoveToThisState<Start>();

            while (result.ActionRequired == ActionRequiredEnum.TransitionToNewState)
            {
                var currentState = GetNewState(result.GetNextState());
                result = currentState.DoAction();
            } 

            if(result.ActionRequired == ActionRequiredEnum.Retry)
            {
                Console.WriteLine($"Looks like we need to retry this later: {context.GetCurrentStateName()}");
            }
        }
    }
}
