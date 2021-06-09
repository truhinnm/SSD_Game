using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    HpSystem hp;

    [SerializeField]
    private WeaponObject weapon;

    private Attack atk;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int curDur;

    // Start is called before the first frame update
    void Start()
    {
        curDur = weapon.Durability;
        atk = player.GetComponent<Attack>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if(atk.isAttacking == true && other.tag == "Enemy") 
        {
            hp = other.gameObject.GetComponent<HpSystem>();
            hp.AdjustHealth(-weapon.AttackDamage);
            curDur--;
            if (curDur == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
