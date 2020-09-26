using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{
    public class Tired : BaseState
    {
        public Tired(IProcessContext context) : base(context) { }

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
