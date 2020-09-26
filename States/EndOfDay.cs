using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class EndOfDay : BaseState
    {
        public EndOfDay(IProcessContext context) : base(context) { }

        public override StateResult DoAction()
        {
            Console.WriteLine("Time to exit");
            return ReturnState<Exit>();
        }
    }
}
