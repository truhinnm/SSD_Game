using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Decisions/Distance")]
    public class DistanceDecision : Decision
    {
        public float distance;
        public override bool Decide(EnemyController enemyController)
        {
            Vector3 direction = enemyController.transform.position - enemyController.player.position;
            float dist = direction.magnitude;

            return dist < distance;
        }
    }
}
