using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private WaypointNetwork network = null;
        [SerializeField] private int[] pathWalkOrder = null;

        public int Count { get => pathWalkOrder.Length; }

        public void Init(WaypointNetwork network, int[] pathWalkOrder)
        {
            this.network = network;
            this.pathWalkOrder = pathWalkOrder;
        }

        public Vector3 GetWaypoint(int index)
        {
            return network.Waypoints[pathWalkOrder[index % pathWalkOrder.Length]].position;
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (network == null || network.Waypoints.Count <= 0) return;

            Gizmos.color = Color.yellow;

            for (int i = 0; i < pathWalkOrder.Length; ++i)
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint((i + 1) % pathWalkOrder.Length));
        }

#endif
    }
}