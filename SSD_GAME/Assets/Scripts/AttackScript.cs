using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    HpSystem hp;

    [SerializeField]
    private bool isAttacking;

    [SerializeField]
    private float dur;

    [SerializeField]
    private float dmg;

    [SerializeField]
    private float curTimeout;

    [SerializeField]
    private float timeout;

    [SerializeField]
    private float attacktime;

    [SerializeField]
    private float attackend;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        curTimeout += Time.deltaTime;
        if (Input.GetMouseButton(0) && transform.parent.tag == "Player")
        {
            if(curTimeout > timeout)
            {
                StartCoroutine(AttackCoroutine());   
                curTimeout = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isAttacking==true && other.tag == "Enemy") 
        {
            hp = other.gameObject.GetComponent<HpSystem>();
            hp.AdjustHealth(-dmg);

        }
    }

    
    IEnumerator AttackCoroutine()
    {
        Debug.Log("A");
        isAttacking = true;
        animator.Play("MouseDownState");
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        Debug.Log("S");
    }
}
