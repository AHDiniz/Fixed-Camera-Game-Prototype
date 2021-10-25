using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI.Test
{
    public class TestSee : MonoBehaviour
    {
        [SerializeField] private string chaseStateName = "";
        [SerializeField] private List<Sensor> sensors = new List<Sensor>();
        [SerializeField] private TestChase chase = null;

        public void Init(StateData data, NavMeshAgent agent)
        {
            for (int i = 0; i < sensors.Count; ++i)
                sensors[i].Init();
        }

        public void Tick(StateData data, StateMachine machine)
        {
            for (int i = 0; i < sensors.Count; ++i)
            {
                if (sensors[i].Targets.Count > 0)
                {
                    chase.SetTarget(sensors[i].Targets[0].transform);
                    machine.GoToState(chaseStateName);
                }
            }
        }
    }
}