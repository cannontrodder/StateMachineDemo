using StateMachineDemo.Interfaces;
using StateMachineDemo.Models;
using System;

namespace StateMachineDemo
{
    public interface IState
    {
        StateResult DoAction();
    }
}
