using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace PPI.AI
{
    public class State : MonoBehaviour
    {
        [System.Serializable]
        public class InitEvent : UnityEvent<StateData, NavMeshAgent>{}

        [System.Serializable]
        public class TickEvent : UnityEvent<StateData, StateMachine>{}

        [System.Serializable]
        public class EndEvent : UnityEvent<StateData>{}

        [SerializeField] private StateData data = null;
        [SerializeField] private InitEvent OnInitEvent = new InitEvent();
        [SerializeField] private TickEvent OnTickEvent = new TickEvent();
        [SerializeField] private EndEvent OnEndEvent = new EndEvent();

        public string Name { get => data.Name; }

        public void Init(NavMeshAgent navMeshAgent)
        {
            OnInitEvent.Invoke(data, navMeshAgent);
        }

        public void Tick(StateMachine stateMachine)
        {
            OnTickEvent.Invoke(data, stateMachine);
        }

        public void End()
        {
            OnEndEvent.Invoke(data);
        }
    }
}