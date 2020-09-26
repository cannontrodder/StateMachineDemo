using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;

namespace StateMachineDemo.States
{
    public class EndOfDay : BaseState<EndOfDay>
    {
        public EndOfDay(IProcessContext context, ILogger logger) : base(context, logger) { }

        public override StateResult DoAction()
        {
            return ReturnState<Exit>();
        }
    }
}
