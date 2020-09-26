using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;

namespace StateMachineDemo.States
{
    public class Tired : BaseState<Tired>
    {
        private readonly ILogger logger;

        public Tired(IProcessContext context, ILogger logger) : base(context, logger)
        {
            this.logger = logger;
        }

        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 22)
            {
                return ReturnState<Sleeping>();
            }

            NextHour();

            return ReturnState<Tired>();
        }
    }
}
