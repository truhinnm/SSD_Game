using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float DmgCount = -10f;

    private HpSystem hp;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            hp = collision.gameObject.GetComponent<HpSystem>();
            hp.AdjustHealth(DmgCount);
        }
    }
}
