using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using StateMachineDemo.Services;
using System;
using System.Reflection.Metadata.Ecma335;

namespace StateMachineDemo.States
{
    public class Awake : BaseState<Awake>
    {
        public Awake(IProcessContext context, ILogger logger) : base(context, logger) { }

        public override StateResult DoAction()
        {
            if (context.HourOfDay >= 20)
            {
                return ReturnState<Tired>();
            }

            NextHour();

            // this is how we'd simulate an failure which we would want to retry 'later'

            if (context.HourOfDay == 19)
            {
                Console.WriteLine($"HANG ON!!! WE COULDN'T TELL WHAT TIME IT IS!!!");
                return StateResult.Retry();
            }

            return ReturnState<Awake>();
        }
    }
}
