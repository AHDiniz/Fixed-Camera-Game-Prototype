using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{
    public class Sensor : MonoBehaviour
    {
        [SerializeField, Range(0f, 360f)] private float angle = 90f;
        [SerializeField] private float detectionCooldown = .2f;
        [SerializeField] private float range = 10f;
        [SerializeField] private LayerMask targetLayer = 0;
        [SerializeField] private LayerMask obstacleLayer = 0;

        private List<Aggravator> targets = new List<Aggravator>();

        public List<Aggravator> Targets { get => targets; }

        public void Init()
        {
            StartCoroutine(FindTargets());
        }

        private IEnumerator FindTargets()
        {
            yield return new WaitForSeconds(detectionCooldown);
            targets.Clear();

            Collider[] targetsInRange = Physics.OverlapSphere(transform.position, range, targetLayer);

            for (int i = 0; i < targetsInRange.Length; ++i)
            {
                Aggravator aggravator = targetsInRange[i].gameObject.GetComponent<Aggravator>();

                if (aggravator != null && aggravator.Active)
                {
                    Transform t = targetsInRange[i].transform;
                    Vector3 direction = (t.position - transform.position).normalized;

                    if (Vector3.Angle(transform.forward, direction) <= angle / 2)
                    {
                        float distance = Vector3.Distance(transform.position, t.position);

                        if (!Physics.Raycast(transform.position, direction, distance, obstacleLayer))
                            targets.Add(aggravator);
                    }
                }
            }

            StartCoroutine(FindTargets());
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);

            Vector3 right = new Vector3(Mathf.Sin(angle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(angle / 2 * Mathf.Deg2Rad)) * range;
            Vector3 left = new Vector3(-Mathf.Sin(angle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(angle / 2 * Mathf.Deg2Rad)) * range;

            right = transform.TransformPoint(right);
            left = transform.TransformPoint(left);

            Gizmos.DrawLine(transform.position, right);
            Gizmos.DrawLine(transform.position, left);
        }

#endif
    }
}