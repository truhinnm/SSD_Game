using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Actions/FollowPlayer")]
    class FollowPlayerAction : Action
    {
        public override void Act(EnemyController enemyController)
        {
            /*if (enemyController.animator.GetBool("Attack"))
                enemyController.animator.SetBool("Attack", false);*/
            enemyController.navMeshAgent.SetDestination(enemyController.player.position);
        }
    }
}
