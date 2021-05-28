using ScriptableStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadWolfScript : MonoBehaviour
{
    [SerializeField] public int flockSize;
    [SerializeField] public GameObject[] flock;
    public Vector3 goal;
    public float speed;
    public float neighbourDistance;
    public float rotationSpeed;
    void Start()
    {
        flock = new GameObject[flockSize];
        for (int i = 0; i < flockSize; i++)
        {        
            flock[i] = GameObject.FindGameObjectWithTag("wolf");
            flock[i].GetComponent<EnemyController>().manager = this;
        }       
    }
    private void Update()
    {
        goal = transform.position;       
    }    
}
