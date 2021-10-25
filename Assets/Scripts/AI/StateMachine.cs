using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private string firstStateName = null;

        private List<State> states = null;
        private Dictionary<string, int> stateLocation = new Dictionary<string, int>();
        private State currentState = null;
        private NavMeshAgent navMeshAgent = null;

        public void Init()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            states = new List<State>(GetComponents<State>());
            for (int i = 0; i < states.Count; ++i)
                stateLocation.Add(states[i].Name, i);
            
            currentState = states[stateLocation[firstStateName]];
            currentState.Init(navMeshAgent);
        }

        public void Tick()
        {
            currentState.Tick(this);
        }

        public void GoToState(string name)
        {
            if (!stateLocation.ContainsKey(name)) return;
            currentState.End();
            int position = stateLocation[name];
            currentState = states[position];
            currentState.Init(navMeshAgent);
        }
    }
}
