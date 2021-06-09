using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableStates
{
    [CreateAssetMenu(menuName ="ScriptableStates/Actions/Waypoints")]
    class WaypointsActions : Action
    {
        public float changeWaypointDistance;
        public override void Act(EnemyController enemyController)
        {
            /*if(CheckDistanceToCurrentWaypoint(enemyController))
            {
                enemyController.currentWaypoint = (enemyController.currentWaypoint + 1);// % enemyController.wpointsLength; 
            }
            enemyController.navMeshAgent.SetDestination(enemyController.CurrentWaypointPosition);*/
            if (CheckDistanceToCurrentWaypoint(enemyController))
            {
                enemyController.currentWaypoint = UnityEngine.Random.Range(0, enemyController.wpointsLength - 1);
            }
            enemyController.navMeshAgent.SetDestination(enemyController.CurrentWaypointPosition);
        }

        private bool CheckDistanceToCurrentWaypoint(EnemyController enemyController)
        {
            Vector3 nextWaypointDirection =
                enemyController.transform.position - enemyController.CurrentWaypointPosition;

            float dist = nextWaypointDirection.magnitude;

            return dist < changeWaypointDistance;
        }
    }
}
