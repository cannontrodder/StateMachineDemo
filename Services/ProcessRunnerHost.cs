using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.States;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StateMachineDemo.Services
{
    public class ProcessRunnerHost : IProcessRunnerHost
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;
        private IProcessContext context;

        public ProcessRunnerHost(IServiceProvider serviceProvider, IProcessContext context, ILogger logger)
        {
            this.serviceProvider = serviceProvider;
            this.context = context;
            this.logger = logger;
        }

        private IState GetNewState(Type instanceType)
        {
            return (IState)ActivatorUtilities.CreateInstance(serviceProvider, instanceType, context);
        }

        public void StartProcess()
        {
            StateResult result = ContinuePreviousStateWhereContextDefinesIt();

            result = RunWorkflow(result);

            switch (result.ActionRequired)
            {
                case ActionRequiredEnum.EndSuccess:
                    logger.Log("End of process, we're done.");
                    break;
                case ActionRequiredEnum.EndFailure:
                    logger.Log("End of process, we're done but this failed (and cannot continue).");
                    break;
                case ActionRequiredEnum.Retry:
                    logger.Log(JsonSerializer.Serialize(context));
                    break;
                default:
                    break;
            }
        }

        private StateResult RunWorkflow(StateResult result)
        {
            while (result.ActionRequired == ActionRequiredEnum.TransitionToNewState)
            {
                var currentState = GetNewState(result.GetNextState());
                result = currentState.DoAction();
            }

            return result;
        }

        private StateResult ContinuePreviousStateWhereContextDefinesIt()
        {
            StateResult result;

            if (!StateResult.TryCreateMoveToThisState(context.CurrentStateName, out result))
                result = GetDefaultStart();

            return result;
        }

        private static StateResult GetDefaultStart()
        {
            return StateResult.MoveToThisState<Start>();
        }
    }
}
