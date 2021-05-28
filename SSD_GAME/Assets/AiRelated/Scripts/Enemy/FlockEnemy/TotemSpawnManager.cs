using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSpawnManager : MonoBehaviour
{
    [SerializeField] public int totemValue;
    [SerializeField] public float spawnRadius;
    [SerializeField] public GameObject wolfTotem;
    [SerializeField] public GameObject[] flock;
    
    void Start()
    {
        flock = new GameObject[totemValue];
        for(int i = 0; i < totemValue; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-spawnRadius, spawnRadius),
                Random.Range(3, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius));
            flock[i] = Instantiate(wolfTotem, transform.position + offset, Quaternion.identity);
            flock[i].GetComponent<FlockManager>().manager = this;
        }
    }  
}
