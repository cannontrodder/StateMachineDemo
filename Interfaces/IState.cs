using StateMachineDemo.Interfaces;
using System;

namespace StateMachineDemo
{
    public interface IState
    {
        Type DoAction();
        bool ShouldExit();
    }
}
