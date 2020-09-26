using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.States
{
    public class Start : BaseState
    {
        public Start(IProcessContext context) : base(context) { }

        public override Type DoAction()
        {
            return ReturnState<Sleeping>();
        }
    }
}
