using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FlockManager manager;
    private float speed;

    private void Start()
    {       
        speed = manager.speed;
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.position + transform.forward *100f, out hit, 2f))
        {
            //Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.green);
            Vector3 direction = Vector3.Reflect(transform.forward, hit.normal);
            EnemySlerp(direction);
            
        }
        else
        {
            ApplyRules();
        }
        transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
    }
    private void ApplyRules()
    {
        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        int flockSize = 0;
        foreach(GameObject go in manager.flock)
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
