using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI.Test
{
    public class TestChase : MonoBehaviour
    {
        [SerializeField] private string attackStateName = "";
        [SerializeField] private float speed = 6f;
        [SerializeField] private float stoppingDistance = 2f;

        private NavMeshAgent agent = null;
        private Transform target = null;
        private float prevStopDist = 0f;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void Init(StateData data, NavMeshAgent agent)
        {
            this.agent = agent;
            agent.speed = speed;
            prevStopDist = agent.stoppingDistance;
            agent.stoppingDistance = stoppingDistance;
        }

        public void Tick(StateData data, StateMachine machine)
        {
            if (agent.isPathStale || !agent.hasPath || agent.pathStatus != NavMeshPathStatus.PathComplete)
            {
                machine.GoToState(attackStateName);
            }
            agent.destination = target.position;
        }

        public void End(StateData data)
        {
            agent.stoppingDistance = prevStopDist;
        }
    }
}