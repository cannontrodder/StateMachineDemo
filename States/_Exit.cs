using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;

namespace StateMachineDemo.States
{
    public class Exit : BaseState<Exit>
    {
        public Exit(IProcessContext context, ILogger logger) : base(context, logger) { }

        public override StateResult DoAction()
        {
            Console.WriteLine("We are exiting");
            return StateResult.End();
        }
    }
}
