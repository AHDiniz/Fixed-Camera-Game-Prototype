using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{
    public class WaypointNetwork : MonoBehaviour
    {
        [SerializeField] private List<Transform> waypoints = new List<Transform>();

        public List<Transform> Waypoints { get => waypoints; }

        public void Init(List<Transform> waypoints)
        {
            this.waypoints = waypoints;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (waypoints.Count <= 0) return;

            Gizmos.color = Color.blue;
            for (int i = 0; i < waypoints.Count - 1; ++i)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
            Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
        }

#endif
    }
}