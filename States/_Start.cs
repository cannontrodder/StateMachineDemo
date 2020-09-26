using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;

namespace StateMachineDemo.States
{
    public class Start : BaseState<Start>
    {
        public Start(IProcessContext context, ILogger logger) : base(context, logger) { }

        public override StateResult DoAction()
        {
            return ReturnState<Sleeping>();
        }
    }
}
