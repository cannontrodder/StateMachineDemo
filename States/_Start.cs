using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class Start : BaseState<Start>
    {
        public Start(IProcessContext context) : base(context) { }

        public override StateResult DoAction()
        {
            return ReturnState<Sleeping>();
        }
    }
}
