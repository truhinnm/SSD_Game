using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableStates
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject waypoint;
        public int wpointsLength;
        public List<Transform> waypoints;
        public int currentWaypoint;
        public Vector3 CurrentWaypointPosition => waypoints[currentWaypoint].position;

        public State currentState;
        public Transform player;
        //public Animator animator;
        public NavMeshAgent navMeshAgent;

        public HeadWolfScript manager;
        private float speed;
        private void Start()
        {
            if (manager != null) speed = manager.speed;
            wpointsLength = Random.Range(3, 5);          
            for (int i = 0; i < wpointsLength; i++)
            {
                Vector3 offset = new Vector3(Random.Range(-15, 15),
                0,
                Random.Range(-15, 15));
                waypoints.Add(Instantiate(waypoint, transform.position + offset, Quaternion.identity).transform);
            }
        }
        public void Update()
        {
            if (manager == null)
            {
                currentState.UpdateState(this);
                manager = FindObjectOfType<HeadWolfScript>();
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.position + transform.forward * 100f, out hit, 2f))
                {
                    //Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.green);
                    Vector3 direction = Vector3.Reflect(transform.forward, hit.normal);
                    EnemySlerp(direction);

                }
                else
                {
                    ApplyRules();
                }
                Vector3 destPos = GameObject.FindGameObjectWithTag("headWolf").transform.position;
                navMeshAgent.SetDestination(destPos- new Vector3(1,0,1));
            }
        }
        public void ChangeState(State nextState)
        {
            if(nextState == null || nextState == currentState)
            {
                return;
            }
            currentState = nextState;
        }
        private void ApplyRules()
        {
            Vector3 center = Vector3.zero;
            Vector3 avoid = Vector3.zero;
            int flockSize = 0;
            foreach (GameObject go in manager.flock)
            {
                if (go == gameObject) continue;

                float distance = Vector3.Distance(transform.position, go.transform.position);

                if (distance > manager.neighbourDistance) continue;

                flockSize++;
                center += go.transform.position;

                if (distance < 5.0f)
                    avoid += transform.position - go.transform.position;

            }
            if (flockSize == 0)
                return;
            center /= flockSize;
            center += manager.goal - transform.position;
            Vector3 direction = center + avoid - transform.position;
            if (direction != Vector3.zero)
                EnemySlerp(direction);

        }
        public void EnemySlerp(Vector3 direction)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction)
                    , manager.rotationSpeed * Time.deltaTime);
        }

    }
}