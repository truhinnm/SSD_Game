using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Decisions/Look")]
    class LookDecision : Decision
    {
        public float lookDistance;
        public override bool Decide(EnemyController enemyController)
        {
            RaycastHit hit;
            if(Physics.Raycast(enemyController.transform.position, enemyController.transform.forward,
                out hit, lookDistance))
            {
                if (hit.collider.GetComponent<PlayerController>() != null)
                    return true;
            }
            return false;
        }
    }
}
