using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class Exit : BaseState<Exit>
    {
        public Exit(IProcessContext context) : base(context) { }

        public override StateResult DoAction()
        {
            Console.WriteLine("We are exiting");
            return StateResult.End();
        }
    }
}
