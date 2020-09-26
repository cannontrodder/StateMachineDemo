using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.States
{
    public class Awake : BaseState
    {
        public Awake(IProcessContext context) : base(context) { }

        public override Type DoAction()
        {
            if (context.HourOfDay >= 20)
            {
                Console.WriteLine($"Getting tired..!");
                return ReturnState<Tired>();
            }

            NextHour();
            
            return ReturnState<Awake>();
        }
    }
}
