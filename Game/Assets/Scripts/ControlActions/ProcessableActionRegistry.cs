using System;
using System.Collections.Generic;

namespace BeatThis.Game.ControlActions
{
    public class ProcessableActionRegistry
    {
        private Dictionary<Type, IProcessableAction> controlActions;

        public ProcessableActionRegistry()
        {
            controlActions = new Dictionary<Type, IProcessableAction>();
        }

        public void AddAction(IProcessableAction action)
        {
            controlActions.Add(action.GetType(), action);
        }

        public void RemoveAction(Type actionType)
        {
            controlActions.Remove(actionType);
        }
        public IProcessableAction GetAction(Type actionType)
        {
            return controlActions[actionType];
        }
    }
}

