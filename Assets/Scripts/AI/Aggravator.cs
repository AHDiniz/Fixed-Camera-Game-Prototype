using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{
    public class Aggravator : MonoBehaviour
    {
        [SerializeField] private bool useCustomTrigger = false;
        [SerializeField] private float range = 1f;

        private SphereCollider col;
        private AudioSource audioSource;

        public bool Active
        {
            get {
                if (audioSource == null) return true;
                else return audioSource.isPlaying;
            }
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();

            if (useCustomTrigger)
            {
                col = GetComponent<SphereCollider>();
                col.isTrigger = true;
                col.radius = range;
            }
        }
    }
}
