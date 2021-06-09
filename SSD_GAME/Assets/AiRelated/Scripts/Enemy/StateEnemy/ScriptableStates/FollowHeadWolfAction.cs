using ScriptableStates;
using UnityEngine;

namespace Assets.AiRelated.Scripts.Enemy.StateEnemy.ScriptableStates
{
    [CreateAssetMenu(menuName = "ScriptableStates/Actions/FollowHeadWolf")]
    class FollowHeadWolfAction : Action
    {
        public override void Act(EnemyController enemyController)
        {
            Vector3 destPos= GameObject.FindGameObjectWithTag("headWolf").transform.position;
            enemyController.navMeshAgent.SetDestination(destPos);
        }
    }
}
