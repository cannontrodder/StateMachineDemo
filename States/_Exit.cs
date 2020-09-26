using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.States
{
    public class Exit : BaseState
    {
        public Exit(IProcessContext context) : base(context) { }

        public override Type DoAction()
        {
            throw new NotImplementedException("Should never call DoAction on the end state");
        }

        public override bool ShouldExit()
        {
            Console.WriteLine("We are exiting");

            return true;
        }
    }
}
