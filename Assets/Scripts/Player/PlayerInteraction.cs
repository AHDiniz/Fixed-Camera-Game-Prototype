using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace PPI.Player
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerInteraction : MonoBehaviour
    {
        [Header("Text Prompt")]
        [SerializeField] private Text textPrompt = null;
        [SerializeField] private string textPromptString = "Interact";

        [Header("Interaction Events")]
        [SerializeField] private UnityEvent OnStart = new UnityEvent();
        [SerializeField] private UnityEvent OnEnterRange = new UnityEvent();
        [SerializeField] private UnityEvent OnInteract = new UnityEvent();
        [SerializeField] private UnityEvent OnExitRange = new UnityEvent();

        private BoxCollider trigger = null;

        private void Start()
        {
            trigger = GetComponent<BoxCollider>();
            trigger.isTrigger = true;
            textPrompt.gameObject.SetActive(false);
            OnStart.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                textPrompt.text = textPromptString;
                textPrompt.gameObject.SetActive(true);
                OnEnterRange.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (Input.GetButton("Jump")) OnInteract.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                textPrompt.gameObject.SetActive(false);
                OnExitRange.Invoke();
            }
        }
    }
}