using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.AI
{  
    [CreateAssetMenu(fileName = "StateData", menuName = "PPI/StateData", order = 0)]
    public class StateData : ScriptableObject
    {
        [SerializeField] private string stateName = "";

        public string Name { get => stateName; }
    }
}