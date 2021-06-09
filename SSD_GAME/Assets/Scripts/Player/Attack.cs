using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private WeaponPickup wp;

    [SerializeField]
    private float curTimeout;

    [SerializeField]
    private float timeout;

    public bool isAttacking;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        wp = GetComponent<WeaponPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        curTimeout += Time.deltaTime;
        if (Input.GetMouseButton(0) && wp.isPicked == true)
        {
            if (curTimeout > timeout)
            {
                StartCoroutine(AttackCoroutine());
                curTimeout = 0;
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        Debug.Log("A");
        isAttacking = true;
        animator.Play("Attack" + wp.weaponName);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        Debug.Log("S");
    }
}
