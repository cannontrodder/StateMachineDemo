using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class Tired : BaseState<Tired>
    {
        public Tired(IProcessContext context) : base(context)
        {
            context.SetCurrentState<Tired>();
        }

        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 22)
            {
                Console.WriteLine($"Bed time!");
                return ReturnState<Sleeping>();
            }

            NextHour();

            return ReturnState<Tired>();
        }
    }
}
