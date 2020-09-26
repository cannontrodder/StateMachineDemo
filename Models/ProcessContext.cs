using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo.Models
{

    public class ProcessContext : IProcessContext
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int HourOfDay { get; set; }
        public string CurrentStateName { get; set; }
    }
}
