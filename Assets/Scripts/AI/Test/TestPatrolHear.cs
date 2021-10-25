using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI.Test
{
    public class TestPatrolHear : MonoBehaviour
    {
        [SerializeField] private string investigateStateName = "";
        [SerializeField] private List<Sensor> sensors = new List<Sensor>();
        [SerializeField] private TestInvestigateWalk investigate = null;
        
        public void Init(StateData data, NavMeshAgent agent)
        {
            for (int i = 0; i < sensors.Count; ++i)
                sensors[i].Init();
        }

        public void Tick(StateData data, StateMachine machine)
        {
            for (int i = 0; i < sensors.Count; ++i)
            {
                if (sensors[i].Targets != null)
                {
                    List<Transform> waypoints = new List<Transform>(sensors[i].Targets.Count);

                    for (int j = 0; j < sensors[i].Targets.Count; ++j)
                        waypoints.Add(sensors[i].Targets[j].transform);

                    investigate.SetRoute(waypoints);
                    machine.GoToState(investigateStateName);
                }
            }
        }
    }
}