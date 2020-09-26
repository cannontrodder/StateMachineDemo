using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.States
{
    public class EndOfDay : BaseState
    {
        public EndOfDay(IProcessContext context) : base(context) { }

        public override Type DoAction()
        {
            Console.WriteLine("Time to exit");
            return ReturnState<Exit>();
        }
    }
}
