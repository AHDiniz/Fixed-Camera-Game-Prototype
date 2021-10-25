using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI.Test
{
    public class TestInvestigateWalk : MonoBehaviour
    {
        [SerializeField] private string patrolStateName = "";
        [SerializeField, Range(1f, 10f)] private float durationMin = 2f;
        [SerializeField] private float speed = 4f;

        private int currentWaypoint = 0;
        private float timeElapsed = 0f, limit = 0f;
        private NavMeshAgent agent = null;
        private Vector2 origin = new Vector2(), target = new Vector2();

        private List<Transform> waypoints = new List<Transform>();

        public void SetRoute(List<Transform> waypoints)
        {
            this.waypoints = waypoints;
        }

        public void Init(StateData data, NavMeshAgent agent)
        {
            this.agent = agent;
            agent.speed = speed;
            limit = durationMin * 60f;
        }

        public void Tick(StateData data, StateMachine machine)
        {
            timeElapsed += Time.deltaTime;

            if (agent != null)
            {
                agent.destination = waypoints[currentWaypoint].position;
                if (agent.isPathStale || !agent.hasPath || agent.pathStatus != NavMeshPathStatus.PathComplete)
                {
                    origin.Set(transform.position.x, transform.position.z);
                    target.Set(agent.destination.x, agent.destination.z);

                    float angle = Vector2.Angle(origin, target);

                    if (angle < .01f) currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
                }
            }

            if (timeElapsed >= limit)
                machine.GoToState(patrolStateName);
        }
    }
}