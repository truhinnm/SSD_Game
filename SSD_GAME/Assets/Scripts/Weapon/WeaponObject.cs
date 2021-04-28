using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
public class WeaponObject : ScriptableObject
{
    [SerializeField]
    private string swordName;
    [SerializeField]
    private int durability;
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private int attackSpeed;
}
