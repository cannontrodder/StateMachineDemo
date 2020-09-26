using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class EndOfDay : BaseState<EndOfDay>
    {
        public EndOfDay(IProcessContext context) : base(context)
        {
            context.SetCurrentState<EndOfDay>();
        }

        public override StateResult DoAction()
        {
            Console.WriteLine("Time to exit");
            return ReturnState<Exit>();
        }
    }
}
