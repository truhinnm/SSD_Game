using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableStates
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(EnemyController enemyController);
    }
}
