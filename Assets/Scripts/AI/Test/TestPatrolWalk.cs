using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PPI.AI.Test
{
    public class TestPatrolWalk : MonoBehaviour
    {
        [SerializeField] private Path path = null;
        [SerializeField] private float speed = 2f;

        private Path currentPath = null;
        private NavMeshAgent agent = null;
        private Vector2 origin = new Vector2(), target = new Vector2();
        private int currentTarget = 0;

        public int Cicles { get; private set; }

        public void Init(StateData data, NavMeshAgent agent)
        {
            this.agent = agent;
            agent.speed = speed;
            currentPath = path;
        }

        public void SetPath(Path path)
        {
            currentPath = path;
        }

        public void Reinit()
        {
            currentPath = path;
        }

        public void Tick(StateData data, StateMachine machine)
        {
            if (agent != null)
            {
                agent.destination = currentPath.GetWaypoint(currentTarget);
                if (agent.isPathStale || !agent.hasPath || agent.pathStatus != NavMeshPathStatus.PathComplete)
                {
                    origin.Set(transform.position.x, transform.position.z);
                    target.Set(agent.destination.x, agent.destination.z);

                    float angle = Vector2.Angle(origin, target);

                    if (angle < .01f) ++currentTarget;

                    if (currentTarget % path.Count == 0) ++Cicles;
                }
            }
            else Debug.LogError("No Nav Mesh Agent attatched!");
        }
    }
}
