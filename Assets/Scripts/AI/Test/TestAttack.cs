using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI.Test
{
    public class TestAttack : MonoBehaviour
    {
        [SerializeField] private string chaseStateName = "";
        [SerializeField] private float pushForce = 5f;
        [SerializeField] private float durationSec = 2f;

        private float timer = 0f;
        private Rigidbody targetBody = null;

        public void SetTarget(Rigidbody targetBody)
        {
            this.targetBody = targetBody;
        }

        public void Init(StateData data, UnityEngine.AI.NavMeshAgent agent)
        {
        }

        public void Tick(StateData data, StateMachine machine)
        {
            timer += Time.deltaTime;
            if (timer >= durationSec) machine.GoToState(chaseStateName);

            // Play attack animation here

            Vector3 direction = targetBody.position - transform.position;
            targetBody.AddForce(direction.normalized * pushForce);
        }
    }
}