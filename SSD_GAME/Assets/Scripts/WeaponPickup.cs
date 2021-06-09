using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    private float dist = 10;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private Transform position;

    public string weaponName = "";

    public bool isPicked = false;

    private GameObject nowPicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        Physics.Raycast(ray, out hit, dist);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "weapon_dropped")
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log("press E to pick up");
                if (Input.GetKeyDown(KeyCode.E) && isPicked == false) 
                {
                    nowPicked = obj;
                    nowPicked.transform.parent = transform;
                    nowPicked.transform.position = position.position;
                    nowPicked.transform.rotation = position.rotation;
                    
                    nowPicked.tag = "Weapon";
                    
                    isPicked = true;
                    nowPicked.GetComponent<AttackScript>().enabled = true;
                    nowPicked.GetComponent<Rigidbody>().isKinematic = true;
                    weaponName = nowPicked.GetComponent<WeaponObject>().SwordName;
                }              
            }           
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        if (Input.GetKeyDown(KeyCode.R) && isPicked == true)
        {
            nowPicked.GetComponent<Animator>().enabled = false;
            Debug.Log("Ping!");
            nowPicked.transform.parent = null;
            nowPicked.GetComponent<AttackScript>().enabled = false;
            nowPicked.tag = "weapon_dropped";
            isPicked = false;
            nowPicked.GetComponent<Rigidbody>().isKinematic = false;
            weaponName = "";
        }
    }
}
