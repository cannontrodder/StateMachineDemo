using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace StateMachineDemo.States
{
    public class Awake : BaseState<Awake>
    {
        public Awake(IProcessContext context) : base(context)
        {
            context.SetCurrentState<Awake>();
        }

        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 20)
            {
                Console.WriteLine($"Getting tired..!");
                return ReturnState<Tired>();
            }

            NextHour();

            if (context.HourOfDay == 19)
            {
                Console.WriteLine($"HANG ON!!! WE COULDN'T TELL WHAT TIME IT IS!!!");
                return StateResult.Retry();
            }

            return ReturnState<Awake>();
        }
    }
}
