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

        private StateResult() { }

        public static bool TryCreateMoveToThisState(string stateName, out StateResult stateResult)
        {
            Type? stateType = null;
            stateResult = null;

            try
            {
                stateType = Type.GetType(stateName);
            }
            catch (Exception) { }

            if (stateType == null)
                return false;

            stateResult = new StateResult();
            stateResult.ActionRequired = ActionRequiredEnum.TransitionToNewState;
            stateResult.nextState = stateType;
            return true;
        }

        public static StateResult MoveToThisState<T>() where T : IState
        {
            var result = new StateResult();
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

        private void SetNextState<T>() where T : IState
        {
            ActionRequired = ActionRequiredEnum.TransitionToNewState;
            nextState = typeof(T);
        }
    }
}
