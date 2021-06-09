using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Transition")]
    public class Transition : ScriptableObject
    {
        public bool invertDecision;
        public Decision decision;
        public State nextState;
    }
}
