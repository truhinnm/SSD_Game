using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private float MaxHealth = 100f;

    [SerializeField]
    private float CurHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    internal void AdjustHealth(float hp)
    {
        CurHealth += hp;
        if (CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }
        Debug.Log(CurHealth);
    }
}
