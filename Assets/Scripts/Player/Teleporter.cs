using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.Player
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private float timeToTeleport = 1f;

        private Transform player = null;

        public void OnStart()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void OnInteract()
        {
            StartCoroutine(Teleport());
        }

        private IEnumerator Teleport()
        {
            yield return new WaitForSeconds(timeToTeleport);
            player.position = target.position;
        }
    }
}