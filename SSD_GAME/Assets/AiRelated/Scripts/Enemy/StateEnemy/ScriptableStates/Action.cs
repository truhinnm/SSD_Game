using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableStates
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(EnemyController enemyController);
    }
}