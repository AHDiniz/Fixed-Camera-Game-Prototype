using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.Player
{
    public class PlayerAnimControl : MonoBehaviour
    {
        [SerializeField] private Animator animControl = null;

        private Vector2 input = new Vector2();

        private void Update()
        {
            input.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            animControl.SetBool("Walking", input != Vector2.zero);
        }
    }
}