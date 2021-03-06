using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow: MonoBehaviour
{
    NavMeshAgent agent; //навмешагент носителя скрипта
    GameObject player; //тег игрока
    Transform[] patrolPoints; //точки патрулирования
    public float speed = 2;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
