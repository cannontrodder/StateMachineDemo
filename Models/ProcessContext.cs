using StateMachineDemo.Interfaces;

namespace StateMachineDemo.Models
{

    public class ProcessContext : IProcessContext
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int HourOfDay { get; set; }
    }
}
