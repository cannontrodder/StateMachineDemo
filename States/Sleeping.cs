using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;

namespace StateMachineDemo.States
{

    public class Sleeping : BaseState<Sleeping>
    {
        public Sleeping(IProcessContext context, ILogger logger) : base(context, logger) { }

        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 24)
            {
                return ReturnState<EndOfDay>();
            }

            if (context.HourOfDay >= 8 && context.HourOfDay < 22)
            {
                return ReturnState<Awake>();
            }

            NextHour();

            return ReturnState<Sleeping>();
        }
    }
}
