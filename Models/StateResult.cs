using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineDemo.Models
{
    public enum ActionRequiredEnum { TransitionToNewState, End, Retry }

    public class StateResult
    {
        public ActionRequiredEnum ActionRequired { get; set; }
        private Type nextState;

        private StateResult()
        {

        }

        public static StateResult MoveToThisState<T>()
        {
            var result = new StateResult();

            result.ActionRequired = ActionRequiredEnum.TransitionToNewState;
            result.SetNextState<T>();
            return result;
        }

        public static StateResult End()
        {
            var result = new StateResult();

            result.ActionRequired = ActionRequiredEnum.End;
            return result;
        }

        public static StateResult Retry()
        {
            var result = new StateResult();

            result.ActionRequired = ActionRequiredEnum.Retry;
            return result;
        }

        public Type GetNextState()
        {
            return nextState;
        }

        private void SetNextState<T>()
        {
            nextState = typeof(T);
        }
    }
}
