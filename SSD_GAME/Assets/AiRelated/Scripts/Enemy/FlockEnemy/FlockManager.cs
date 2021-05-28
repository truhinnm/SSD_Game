using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    [SerializeField] public  int flockSize;
    [SerializeField] public float spawnRadius;
    [SerializeField] public GameObject wolfEnemy;
    [SerializeField] public GameObject[] flock;
    public Vector3 goal;
    public float speed;
    public float neighbourDistance;
    public float rotationSpeed;
    public TotemSpawnManager manager;
    void Start()
    {
        flock = new GameObject[flockSize];
        for(int i = 0; i < flockSize; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(-spawnRadius, spawnRadius));
            flock[i] = Instantiate(wolfEnemy, transform.position + offset, Quaternion.identity);
            flock[i].GetComponent<Enemy>().manager = this;
        }
        StartCoroutine(TotemLerp()); 
    }
    private void Update()
    {
        goal = transform.position;
        /*if(Input.GetMouseButton(0))
        {
            speed += 4;
            //goal = Input.mousePosition;
            // Debug.Log(Input.mousePosition);
            goal = new Vector3(0, 3, 0);
        }*/
    }
    private IEnumerator TotemLerp()
    {
        Vector3 posA = transform.position;
        Vector3 posB = new Vector3(transform.position.x, posA.y-1, transform.position.z);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            transform.position = Vector3.Lerp(transform.position,
                posB, 5f);

            yield return new WaitForSeconds(Random.Range(2, 5));
            transform.position = Vector3.Lerp(transform.position,
                posA, 5f);           
        }
    }
}
