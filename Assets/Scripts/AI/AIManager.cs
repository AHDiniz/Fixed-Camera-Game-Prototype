using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField] private List<StateMachine> stateMachines = new List<StateMachine>();

        private void Start()
        {
            for (int i = 0; i < stateMachines.Count; ++i)
            {
                stateMachines[i].Init();
            }
        }

        private void Update()
        {
            for (int i = 0; i < stateMachines.Count; ++i)
            {
                stateMachines[i].Tick();
            }
        }
    }
}