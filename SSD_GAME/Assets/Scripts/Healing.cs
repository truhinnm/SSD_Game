using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField]
    private float HealingCount = 10f;

    private HpSystem hp;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ping");
        if (other.tag == "Player")
        {
            hp = other.gameObject.GetComponent<HpSystem>();
            hp.AdjustHealth(HealingCount);
            Destroy(gameObject);
        }
    }
}
