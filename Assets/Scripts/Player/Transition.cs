using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PPI.Player
{
    public class Transition : MonoBehaviour
    {
        [SerializeField] private Image transitionSprite = null;
        [SerializeField] private float inDuration = .5f;
        [SerializeField] private float intermission = .1f;
        [SerializeField] private float outDuration = .5f;

        private float inSpeed, outSpeed;
        private float cutoff = 0f;

        private bool start = false, end = false;

        public void OnStart()
        {
            inSpeed = 1 / inDuration;
            outSpeed = 1 / outDuration;
        }

        public void OnInteract()
        {
            start = true;
        }

        private void Update()
        {
            if (start)
            {
                cutoff += inSpeed * Time.deltaTime;
                transitionSprite.material.SetFloat("_Cutoff", cutoff);
                if (cutoff >= 1f)
                {
                    start = false;
                    StartCoroutine(Intermission());
                }
            }

            if (end)
            {
                cutoff -= outSpeed * Time.deltaTime;
                transitionSprite.material.SetFloat("_Cutoff", cutoff);
                if (cutoff <= 0f)
                {
                    end = false;
                    cutoff = 0f;
                }
            }
        }

        private IEnumerator Intermission()
        {
            yield return new WaitForSeconds(intermission);
            end = true;
        }
    }
}