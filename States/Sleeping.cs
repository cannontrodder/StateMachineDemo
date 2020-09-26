using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo.States
{

    public class Sleeping : BaseState<Sleeping>
    {
        public Sleeping(IProcessContext context) : base(context)
        {
            context.SetCurrentState<Sleeping>();
        }
        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 24)
            {
                Console.WriteLine($"Reaching end of day");
                return ReturnState<EndOfDay>();
            }

            if (context.HourOfDay >= 8 && context.HourOfDay < 22)
            {
                Console.WriteLine($"Wake up!");
                return ReturnState<Awake>();
            }

            NextHour();

            return ReturnState<Sleeping>();
        }
    }
}
