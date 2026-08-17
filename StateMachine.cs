using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class StateMachine<TState> where TState : Enum
{
        [SerializeField] string _currentStateName;
        IState<StateMachine<TState>> _currentState;
        
        Dictionary<TState, IState<StateMachine<TState>>> _states = new Dictionary<TState, IState<StateMachine<TState>>>();

        public void AddState(TState stateName, IState<StateMachine<TState>> state)
        {
            _states[stateName] = state;
            state.StateMachine = this;
        }

        public void ChangeState(TState stateName)
        {
            if(!_states.ContainsKey(stateName))
            {
                Debug.Log("questa state machine:" + stateName + " non esiste");
                return;
            }
            _currentState?.Exit();

            _currentState = _states[stateName];
            
            _currentStateName = stateName.ToString();

            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Execute();
        }



}
