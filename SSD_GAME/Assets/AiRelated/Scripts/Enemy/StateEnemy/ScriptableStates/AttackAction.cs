using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Actions/Attack")]
    class AttackAction : Action
    {
        public override void Act(EnemyController enemyController)
        {
            /*if (!enemyController.animator.GetBool("Attack"))
                enemyController.animator.SetBool("Attack", true);*/
        }
    }
}
